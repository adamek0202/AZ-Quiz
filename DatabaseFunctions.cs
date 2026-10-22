using AZ_Kviz.Configuration;
using AZ_Kviz.Forms;
using AZ_Kviz.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace AZ_Kviz
{
    public enum QuestionSelectionMode
    {
        Random,
        RandomWithSeed,
        Sequential
    }

    internal sealed class DatabaseFunctions : IDisposable
    {
        private readonly string databaseFileName;
        private readonly AppConfig config;
        private readonly Random random = new Random();
        private SQLiteConnection _connection;

        private SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection($"Data Source={databaseFileName};Version=3");
                    _connection.Open();
                }
                return _connection;
            }
        }

        public DatabaseFunctions(string databaseFileName, AppConfig config)
        {
            this.databaseFileName = databaseFileName ?? throw new ArgumentNullException(nameof(databaseFileName));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private SQLiteConnection OpenConnection()
        {
            var connection = new SQLiteConnection($"Data Source={databaseFileName};Version=3");

            connection.Open();
            return connection;
        }

        public bool InitDatabase()
        {
            if (!File.Exists(databaseFileName))
            {
                Log.Warning("Databáze neexistuje. Pokus o vytvoření nové...");
                CreateDatabase();
                return true;
            }
            try
            {
                using var _ = OpenConnection();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Selhalo otevření databáze {DatabaseFile}", databaseFileName);
                throw;
            }
            if (!CheckDatabaseIntegrity())
            {
                Log.Fatal("Došlo k porušení integrity databáze");
                return false;
            }
            return true;
        }

        public void RecreateDatabase()
        {
            CloseConnection();
            File.Delete(databaseFileName);
            CreateDatabase();
        }

        public bool CheckDatabaseIntegrity()
        {
            using (SqlCursorManager.Show())
            using(var connection = OpenConnection())
            using (var cmd = new SQLiteCommand("PRAGMA integrity_check;", connection))
            {
                var result = cmd.ExecuteScalar()?.ToString();
                return result == "ok";
            }
        }

        public void CreateDatabase()
        {
            Log.Information("Vytváření nové databáze...");

            // Nejdřív vytvoříme strukturu tabulek včetně chybějící QuestionSets a sloupce used
            string cmd = @"
                CREATE TABLE ""QuestionSets"" (
                    ""id"" INTEGER NOT NULL UNIQUE,
                    ""name"" TEXT NOT NULL DEFAULT """",
                    ""scope"" TEXT NOT NULL DEFAULT """",
                    ""difficulty"" INTEGER NOT NULL DEFAULT 1,
                    PRIMARY KEY(""id"" AUTOINCREMENT)
                );

                CREATE TABLE ""Questions"" (
                    ""id""     INTEGER NOT NULL UNIQUE,
                    ""text""   TEXT NOT NULL DEFAULT """",
                    ""answer"" TEXT NOT NULL DEFAULT """",
                    ""set_id""  INTEGER NOT NULL DEFAULT 0,
                    ""setpos"" INTEGER NOT NULL DEFAULT 0,
                    ""used""   INTEGER NOT NULL DEFAULT 0,
                    ""is_replacement"" INTEGER NOT NULL DEFAULT 0,
                    PRIMARY KEY(""id"" AUTOINCREMENT),
                    FOREIGN KEY(""set_id"") REFERENCES ""QuestionSets""(""id"")
                );
               CREATE INDEX ""QuestionSetID"" ON ""Questions"" (""set_id"" ASC);";

            try
            {
                using (SqlCursorManager.Show())
                using (var connection = OpenConnection())
                using (var command = new SQLiteCommand(cmd, connection))
                {
                    command.ExecuteNonQuery();
                }
                Log.Information("Nová databáze byla úspěšně vytvořena");
            }
            catch (Exception ex)
            {
                Log.Error($"Nastala chyba při vytváření tabulek: {ex.Message}");
                throw new InvalidOperationException("Nepodařilo se vytvořit databázové tabulky.", ex);
            }
        }

        public Task<DataTable> GetQuestionTableAsync(uint setId, bool replacement)
        {
            return Task.Run(() => GetQuestionTable(setId, replacement));
        }

        public DataTable GetQuestionTable(uint setId, bool replacement)
        {
            var dataTable = new DataTable();
            const string query = @"SELECT id, set_id, text, answer, is_replacement,
                                   ROW_NUMBER() OVER (ORDER BY id) AS DisplayOrder
                                   FROM Questions
                                   WHERE set_id = @set_id
                                   AND ((@replacement = 1 AND is_replacement = 1)
                                        OR (@replacement = 0 AND (is_replacement = 0 OR is_replacement IS NULL)))
                                   ORDER BY id";
            try
            {
                using (var connection = OpenConnection())
                using (var command = new SQLiteCommand(query, connection))
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@set_id", setId);
                    command.Parameters.AddWithValue("@replacement", replacement ? 1 : 0);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Chyba při načítání dat: {ex.Message}", ex);
            }
            return dataTable;
        }

        public void SaveTable(DataTable table)
        {
            try
            {
                using (SqlCursorManager.Show())
                using (var connection = OpenConnection())
                using (var transaction = connection.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand(
                        "UPDATE Questions SET text = @text, answer = @answer WHERE id = @id AND set_id = @set_id",
                        connection,
                        transaction))
                    {
                        var textParameter = cmd.Parameters.Add("@text", DbType.String);
                        var answerParameter = cmd.Parameters.Add("@answer", DbType.String);
                        var idParameter = cmd.Parameters.Add("@id", DbType.Int64);
                        var setIdParameter = cmd.Parameters.Add("@set_id", DbType.Int64);

                        foreach (DataRow row in table.Rows)
                        {
                            if (row.RowState != DataRowState.Modified)
                            {
                                continue;
                            }

                            textParameter.Value = row["text"] ?? DBNull.Value;
                            answerParameter.Value = row["answer"] ?? DBNull.Value;
                            idParameter.Value = row["id"];
                            setIdParameter.Value = row["set_id"];
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    table.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Chyba při ukládání dat do databáze: {ex.Message}", ex);
            }
        }

        public Task<uint> CreateNewQuestionSetAsync(string setName, string scope, uint difficulty)
        {
            return Task.Run(() => CreateNewQuestionSet(setName, scope, difficulty));
        }

        public uint CreateNewQuestionSet(string setName, string scope, uint difficulty)
        {
            uint newSetId;

            using (SqlCursorManager.Show())
            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. Vložíme novou sadu
                    string insertSetQuery = "INSERT INTO QuestionSets (name, scope, difficulty) VALUES (@name, @scope, @difficulty); SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(insertSetQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", setName);
                        cmd.Parameters.AddWithValue("@scope", scope); // OPRAVENO: Už žádná složená závorka
                        cmd.Parameters.AddWithValue("@difficulty", difficulty);
                        newSetId = Convert.ToUInt32(cmd.ExecuteScalar());
                    }

                    // 2. Vygenerujeme 28 normálních a 28 náhradních otázek
                    string insertQuestionQuery = "INSERT INTO Questions (set_id, text, answer, is_replacement, setpos) VALUES (@set_id, @text, @answer, @isReplacement, @questionOrder)";
                    using (var cmd = new SQLiteCommand(insertQuestionQuery, connection, transaction))
                    {
                        // Parametry stačí založit jednou před cykly
                        cmd.Parameters.AddWithValue("@set_id", newSetId);
                        var textParam = cmd.Parameters.AddWithValue("@text", string.Empty);
                        cmd.Parameters.AddWithValue("@answer", string.Empty);
                        var replacementParam = cmd.Parameters.AddWithValue("@isReplacement", 0);
                        var orderParam = cmd.Parameters.AddWithValue("@questionOrder", 1);

                        // Normální otázky 1-28
                        replacementParam.Value = 0;
                        for (int i = 1; i <= 28; i++)
                        {
                            textParam.Value = $"Otázka {i}";
                            orderParam.Value = i;
                            cmd.ExecuteNonQuery();
                        }

                        // Náhradní otázky 1-28
                        replacementParam.Value = 1;
                        for (int i = 1; i <= 28; i++)
                        {
                            textParam.Value = $"Náhradní otázka {i}";
                            orderParam.Value = i;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Chyba při vytváření sady: {ex.Message}", ex);
                }
            }

            return newSetId;
        }

        public void DeleteQuestionsSet(uint setId)
        {
            if (setId == 0)
            {
                throw new ArgumentException("ID sady nemůže být nula");
            }
            using (SqlCursorManager.Show())
            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    string deleteQuestionsQuery = "DELETE FROM Questions WHERE set_id = @set_Id";
                    using (var cmd = new SQLiteCommand(deleteQuestionsQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@set_Id", setId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteSetQuery = "DELETE FROM QuestionSets WHERE id = @set_Id";
                    using (var cmd = new SQLiteCommand(deleteSetQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@set_Id", setId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Log.Information($"Sada otázek {setId} byla úspěšně smazána");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Chyba při čištění stornované sady (ID {setId}): {ex.Message}", ex);
                }
            }
        }

        public Question GetQuestion(uint setId, uint fieldId, bool replacement = false)
        {
            QuestionSelectionMode mode;
            if (config.Database.ShuffleQuestions)
            {
                mode = config.System.RandomGeneratorSeed.HasValue && config.System.RandomGeneratorSeed.Value != 0
                    ? QuestionSelectionMode.RandomWithSeed
                    : QuestionSelectionMode.Random;
            }
            else
            {
                mode = QuestionSelectionMode.Sequential;
            }

            int seed = config.System.RandomGeneratorSeed ?? 0;
            string query = mode switch
            {
                QuestionSelectionMode.Sequential => @"SELECT id, text, answer, used FROM Questions
                    WHERE set_id = @set_id AND setpos = @field_id AND used = 0
                    AND ((@replacement = 1 AND is_replacement = 1)
                         OR (@replacement = 0 AND (is_replacement = 0 OR is_replacement IS NULL)))
                    ORDER BY id LIMIT 1",
                QuestionSelectionMode.RandomWithSeed => @"SELECT id, text, answer, used FROM Questions
                    WHERE set_id = @set_id
                    AND ((@replacement = 1 AND is_replacement = 1)
                         OR (@replacement = 0 AND (is_replacement = 0 OR is_replacement IS NULL)))
                    ORDER BY setpos, id",
                _ => @"SELECT id, text, answer, used FROM Questions
                    WHERE set_id = @set_id AND used = 0
                    AND ((@replacement = 1 AND is_replacement = 1)
                         OR (@replacement = 0 AND (is_replacement = 0 OR is_replacement IS NULL)))
                    ORDER BY id"
            };

            var candidates = new List<QuestionCandidate>();

            using (SqlCursorManager.Show())
            using (var connection = OpenConnection())
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@set_id", setId);
                cmd.Parameters.AddWithValue("@replacement", replacement ? 1 : 0);
                if (mode == QuestionSelectionMode.Sequential)
                {
                    cmd.Parameters.AddWithValue("@field_id", fieldId);
                }
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        do
                        {
                            var question = new Question(
                                reader["text"]?.ToString() ?? string.Empty,
                                reader["answer"]?.ToString() ?? string.Empty,
                                Convert.ToUInt32(reader["id"]));
                            bool used = Convert.ToInt32(reader["used"]) != 0;
                            candidates.Add(new QuestionCandidate(question, used));
                        }
                        while (reader.Read());
                    }
                }
            }

            if (mode == QuestionSelectionMode.Sequential)
            {
                if (candidates.Count > 0)
                {
                    return candidates[0].Question;
                }

                throw new EmptyDatasetException($"Pro políčko {fieldId} v sadě {setId} není dostupná otázka.");
            }

            if (mode == QuestionSelectionMode.RandomWithSeed)
            {
                int deterministicSeed = unchecked(seed ^ (int)setId ^ (replacement ? int.MinValue : 0));
                var seededRandom = new Random(deterministicSeed);
                for (int i = candidates.Count - 1; i > 0; i--)
                {
                    int j = seededRandom.Next(i + 1);
                    QuestionCandidate candidate = candidates[i];
                    candidates[i] = candidates[j];
                    candidates[j] = candidate;
                }

                foreach (QuestionCandidate candidate in candidates)
                {
                    if (!candidate.Used)
                    {
                        return candidate.Question;
                    }
                }
            }
            else if (candidates.Count > 0)
            {
                return candidates[random.Next(candidates.Count)].Question;
            }

            throw new EmptyDatasetException($"V sadě {setId} již nejsou žádné nepoužité otázky.");
        }

        public void MarkQuestionUsed(uint id)
        {
            string query = "UPDATE Questions SET used = 1 WHERE id = @id";
            using (SqlCursorManager.Show())
            using(var connection = OpenConnection())
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void ResetQuestionUsage(uint setId)
        {

            string query = "UPDATE Questions SET used = 0 WHERE set_id = @set_id";
            try
            {
                using (SqlCursorManager.Show())
                using (var connection = OpenConnection())
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@set_id", setId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Chyba ři resetování stavu použití otázek");
                throw;
            }
        }

        public Task<List<QuestionSet>> GetAllQuestionsSetsAsync()
        {
            return Task.Run(() => GetAllQuestionSets());
        }

        private List<QuestionSet> GetAllQuestionSets()
        {
            var sets = new List<QuestionSet>();
            string querry = "SELECT id, name, scope, difficulty FROM QuestionSets ORDER BY id ASC";

            try
            {
                using(var connection = OpenConnection())
                using (var cmd = new SQLiteCommand(querry, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            uint id = Convert.ToUInt32(reader["id"]);
                            string name = reader["name"].ToString();
                            string scope = reader["scope"].ToString();
                            uint difficulty = Convert.ToUInt32(reader["difficulty"]);

                            sets.Add(new QuestionSet(id, name, scope, difficulty));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Chyba při načítání sad otázek z DB: {ex.Message}", ex);
            }
            return sets;
        }

        private sealed class QuestionCandidate
        {
            public Question Question { get; }
            public bool Used { get; }

            public QuestionCandidate(Question question, bool used)
            {
                Question = question;
                Used = used;
            }
        }

        private void CloseConnection()
        {
            _connection?.Dispose();
            _connection = null;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
