using System;
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
                CreateDatabase();
                return true;
            }
            try
            {
                var _ = DatabaseConnection.Connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nelze otevřít databázi: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!CheckDatabaseIntegrity())
            {
                MessageBox.Show("Integrita databáze byla porušena!", "Chyba databáze", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (MessageBox.Show("Chcete vytvořit novou (prázdnou) databázi?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            using (var cmd = new SQLiteCommand("PRAGMA integrity_check;", DatabaseConnection.Connection))
            {
                var result = cmd.ExecuteScalar()?.ToString();
                return result == "ok";
            }
        }

        public static void CreateDatabase()
        {
            MessageBox.Show("Databáze nebyla nalezena, bude vytvořena nová...", "Chybí databáze", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Nejdřív vytvoříme strukturu tabulek včetně chybějící QuestionSets a sloupce used
            string cmd = @"
                CREATE TABLE ""QuestionSets"" (
                    ""id"" INTEGER NOT NULL UNIQUE,
                    ""name"" TEXT NOT NULL DEFAULT """",
                    PRIMARY KEY(""id"" AUTOINCREMENT)
                );

                CREATE TABLE ""Questions"" (
                    ""id""     INTEGER NOT NULL UNIQUE,
                    ""text""   TEXT NOT NULL DEFAULT """",
                    ""answer"" TEXT NOT NULL DEFAULT """",
                    ""setid""  INTEGER NOT NULL DEFAULT 0,
                    ""setpos"" INTEGER NOT NULL DEFAULT 0,
                    ""used""   INTEGER NOT NULL DEFAULT 0,
                    PRIMARY KEY(""id"" AUTOINCREMENT),
                    FOREIGN KEY(""setid"") REFERENCES ""QuestionSets""(""id"")
                );
               CREATE INDEX ""QuestionSetID"" ON ""Questions"" (""setid"" ASC);";

            try
            {
                using (var command = new SQLiteCommand(cmd, DatabaseConnection.Connection))
                {
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Databáze byla úspěšně vytvořena.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nastala chyba při vytváření tabulek: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static Question GetQuestion(uint setid, bool replacement = false)
        {
            if (!TableNotEmpty("Questions"))
            {
                throw new Exception("Tabulka neobsahuje žádná data.");
            }

            // Vybere JEDNU náhodnou otázku z dané sady, která ještě nebyla použitá
            // ORDER BY RANDOM() je pro SQLite ideální způsob
            string query = "SELECT id, text, answer FROM Questions WHERE setid = @setid AND used = 0 ORDER BY RANDOM() LIMIT 1";

            using (var cmd = new SQLiteCommand(query, DatabaseConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@setid", setid);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        uint id = Convert.ToUInt32(reader["id"]);
                        string text = reader["text"].ToString();
                        string answer = reader["answer"].ToString();

                        MarkQuestionUsed(id);
                        return new Question(text, answer, id);
                    }
                }
            }

            throw new Exception($"V sadě {setid} již nejsou žádné nepoužité otázky!");
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
    }
}
