using AZ_Kviz.Forms;
using AZ_Kviz.Models;
using AZ_Kviz.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal static class DatabaseConnection
    {
        private static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection($"Data Source={DatabaseFunctions.DbName};Version=3");
                    _connection.Open();
                }
                return _connection;
            }
        }

            public static void CloseConnection()
            {
                _connection?.Close();
                _connection = null;
            }
    }

    internal static class DatabaseFunctions
    {
        public const string DbName = "data.db";
        public static bool InitDatabase()
        {
            if (!File.Exists(DbName))
            {
                Log.Warning("Databáze neexistuje. Pokus o vytvoření nové...");
                CreateDatabase();
                return true;
            }
            try
            {
                var _ = DatabaseConnection.Connection;
            }
            catch (Exception ex)
            {
                MsgBoxes.ErrorBox($"Nelze otevřít databázi: {ex.Message}");
                Log.Error($"Selhalo otevření databáze: {ex.Message}");
                return false;
            }
            if (!CheckDatabaseIntegrity())
            {
                MsgBoxes.FatalBox("Integrita databáze byla porušena!", "Chyba databáze");
                Log.Fatal("Došlo k porušení integrity databáze");
                if (MsgBoxes.QuestionBox("Chcete vytvořit novou (prázdnou) databázi?"))
                {
                    DatabaseConnection.CloseConnection(); // Musíme uvolnit zámek souboru
                    File.Delete(DbName);
                    CreateDatabase();
                    return true;
                }
                return false;
            }
            return true;
        }

        public static bool CheckDatabaseIntegrity()
        {
            using (SqlCursorManager.Show())
            using (var cmd = new SQLiteCommand("PRAGMA integrity_check;", DatabaseConnection.Connection))
            {
                var result = cmd.ExecuteScalar()?.ToString();
                return result == "ok";
            }
        }

        public static void CreateDatabase()
        {
            MessageBox.Show("Databáze nebyla nalezena, bude vytvořena nová...", "Chybí databáze", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                using (var command = new SQLiteCommand(cmd, DatabaseConnection.Connection))
                {
                    command.ExecuteNonQuery();
                }
                MsgBoxes.InfoBox("Databáze byla úspěšně vytvořena.");
                Log.Information("Nová databáze byla úspěšně vytvořena");
            }
            catch (Exception ex)
            {
                Log.Error($"Nastala chyba při vytváření tabulek: {ex.Message}");                                                  
                MsgBoxes.ErrorBox($"Nastala chyba při vytváření tabulek: {ex.Message}");
            }
        }

        public static bool TableNotEmpty(string table)
        {
            // Bezpečnější olemování názvu tabulky
            string query = $"SELECT COUNT(*) from \"{table}\"";
            using (var cmd = new SQLiteCommand(query, DatabaseConnection.Connection))
            {
                long count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public static DataTable GetTable(string sqlQuerry)
        {
            var dataTable = new DataTable();
            try
            {
                using(var adapter = new SQLiteDataAdapter(sqlQuerry, DatabaseConnection.Connection))
                {
                    adapter.Fill(dataTable);
                }
            } catch (Exception ex)
            {
                throw new Exception($"Chyba při načítání dat: {ex.Message}", ex);
            }
            return dataTable;
        }

        public static void SaveTable(DataTable table, string selectQuerry)
        {
            try
            {
                using(SqlCursorManager.Show())
                using(var adapter = new SQLiteDataAdapter(selectQuerry, DatabaseConnection.Connection))
                {
                    using(var builder = new SQLiteCommandBuilder(adapter))
                    {
                        adapter.Update(table);
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception($"Chyba při ukládání dat do databáze: {ex.Message}", ex);
            }
        }

        public static uint CreateNewQuestionSet(string setName, string scope, uint difficulty)
        {
            uint newSetId = 0;

            using (var transaction = DatabaseConnection.Connection.BeginTransaction())
            {
                try
                {
                    // 1. Vložíme novou sadu
                    string insertSetQuery = "INSERT INTO QuestionSets (name, scope, difficulty) VALUES (@name, @scope, @difficulty); SELECT last_insert_rowid();";
                    using (var cmd = new SQLiteCommand(insertSetQuery, DatabaseConnection.Connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", setName);
                        cmd.Parameters.AddWithValue("@scope", scope); // OPRAVENO: Už žádná složená závorka
                        cmd.Parameters.AddWithValue("@difficulty", difficulty);
                        newSetId = Convert.ToUInt32(cmd.ExecuteScalar());
                    }

                    // 2. Vygenerujeme 28 normálních a 28 náhradních otázek
                    string insertQuestionQuery = "INSERT INTO Questions (set_id, text, answer, is_replacement) VALUES (@set_id, @text, @answer, @isReplacement)";
                    using (var cmd = new SQLiteCommand(insertQuestionQuery, DatabaseConnection.Connection, transaction))
                    {
                        // Parametry stačí založit jednou před cykly
                        cmd.Parameters.AddWithValue("@set_id", newSetId);
                        var textParam = cmd.Parameters.AddWithValue("@text", string.Empty);
                        cmd.Parameters.AddWithValue("@answer", string.Empty);
                        var replacementParam = cmd.Parameters.AddWithValue("@isReplacement", 0);

                        // Normální otázky 1-28
                        replacementParam.Value = 0;
                        for (int i = 1; i <= 28; i++)
                        {
                            textParam.Value = $"Otázka {i}";
                            cmd.ExecuteNonQuery();
                        }

                        // Náhradní otázky 1-28
                        replacementParam.Value = 1;
                        for (int i = 1; i <= 28; i++)
                        {
                            textParam.Value = $"Náhradní otázka {i}";
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

        public static void DeleteQuestionsSet(uint setId)
        {
            if(setId == 0)
            {
                throw new ArgumentException("ID sady nemůže být nula");
            }
            using (var transaction = DatabaseConnection.Connection.BeginTransaction())
            {
                try
                {
                    string deleteQuestionsQuery = "DELETE FROM Questions WHERE set_id = @set_Id";
                    using (var cmd = new SQLiteCommand(deleteQuestionsQuery, DatabaseConnection.Connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@set_Id", setId);
                        cmd.ExecuteNonQuery();
                    }

                    string deleteSetQuery = "DELETE FROM QuestionSets WHERE id = @set_Id";
                    using (var cmd = new SQLiteCommand(deleteSetQuery, DatabaseConnection.Connection, transaction))
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

        public static Question GetQuestion(uint setid, bool replacement = false)
        {
            if (!TableNotEmpty("Questions"))
            {
                throw new Exception("Tabulka neobsahuje žádná data.");
            }

            // Vybere JEDNU náhodnou otázku z dané sady, která ještě nebyla použitá
            // ORDER BY RANDOM() je pro SQLite ideální způsob
            string query = @"SELECT id, text, answer FROM Questions 
                             WHERE set_id = @set_id AND used = 0 AND is_replacement = @replacement 
                             ORDER BY RANDOM() LIMIT 1";

            using (var cmd = new SQLiteCommand(query, DatabaseConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@set_id", setid);
                cmd.Parameters.AddWithValue("@replacement", replacement ? 1 : 0);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        uint id = Convert.ToUInt32(reader["id"]);
                        string text = reader["text"].ToString();
                        string answer = reader["answer"].ToString();
                        return new Question(text, answer, id);
                    }
                }
            }

            throw new EmptyDatasetException($"V sadě {setid} již nejsou žádné nepoužité otázky!");
        }

        public static void MarkQuestionUsed(uint id)
        {
            string query = "UPDATE Questions SET used = 1 WHERE id = @id";
            using (var cmd = new SQLiteCommand(query, DatabaseConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ResetQuestionUsage(uint setId)
        {

            string query = "UPDATE Questions SET used = 0 WHERE set_id = @set_id";
            try
            {
                using(SqlCursorManager.Show())
                using (var cmd = new SQLiteCommand(query, DatabaseConnection.Connection))
                {
                    cmd.Parameters.AddWithValue("@set_id", setId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Chyba při resetování příznaku použití otázek: {ex.Message}", ex);
            }
        }

        public static List<QuestionSet> GetAllQuestionSets()
        {
            var sets = new List<QuestionSet>();
            string querry = "SELECT id, name, scope, difficulty FROM QuestionSets ORDER BY id ASC";

            try
            {
                using(var cmd = new SQLiteCommand(querry, DatabaseConnection.Connection))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            uint id = Convert.ToUInt32(reader["id"]);
                            string name = reader["name"].ToString() ?? "?";
                            string scope = reader["scope"].ToString() ?? "?";
                            uint difficulty = Convert.ToUInt32(reader["difficulty"]);

                            sets.Add(new QuestionSet(id, name, scope, difficulty));
                        }
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception($"Chyba při načítání sad otázek z DB: {ex.Message}", ex);
            }
            return sets;
        }
    }
}
