using System;
using System.Collections.Generic;
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
            else
            {
                try
                {
                    var _ = DatabaseConnection.Connection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Nastala chyba: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!CheckDatabaseIntegrity())
                {
                    MessageBox.Show("Integrita databáze byla porušena", "Chyba databáze", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if(MessageBox.Show("Chcete vytvořit novou databázi?", "Dotaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(DbName);
                        CreateDatabase();
                        return true;
                    }
                }
                return true;
            }
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
            try
            {
                var _ = DatabaseConnection.Connection;
            } catch(Exception ex)
            {
                MessageBox.Show($"Nastala chyba: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string cmd = @"
                CREATE TABLE ""Questions"" (
	                ""id""	INTEGER NOT NULL UNIQUE,
	                ""text""	TEXT NOT NULL DEFAULT """",
	                ""answer""	TEXT NOT NULL DEFAULT """",
	                ""setid""	INTEGER NOT NULL DEFAULT 0,
	                PRIMARY KEY(""id"" AUTOINCREMENT),
	                FOREIGN KEY(""setid"") REFERENCES ""QuestionSets""(""id"")
                );
                CREATE TABLE ""QuestionSets"" (
	                ""id""	INTEGER NOT NULL UNIQUE,
	                ""name""	TEXT NOT NULL DEFAULT """",
                    ""scope""	TEXT NOT NULL DEFAULT """",
                    ""author""	TEXT NOT NULL DEFAULT """",
	                ""difficulty""	INTEGER NOT NULL DEFAULT 0,
	                PRIMARY KEY(""id"" AUTOINCREMENT)
            ); CREATE INDEX ""QuestionSetID"" ON ""Questions"" (""setid"" ASC);";
            using (var command = new SQLiteCommand(cmd, DatabaseConnection.Connection))
            {
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Databáze byla úspěšně vytvořena", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool TableNotEmpty(string table)
        {
            string querry = $"SELECT COUNT(*) from {table}";
            using(var cmd = new SQLiteCommand(querry, DatabaseConnection.Connection))
            {
                long count = (long)cmd.ExecuteScalar();
                if(count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static List<QuestionsSet> GetQuestionSets()
        {
            if (!TableNotEmpty("QuestionSets"))
            {
                throw new EmptyDatasetException("Tabulka neobsahuje žádná data");
            }
            string querry = "SELECT * FROM QuestionSets;";
            List<QuestionsSet> sets = new List<QuestionsSet>();
            using(var cmd = new SQLiteCommand(querry, DatabaseConnection.Connection))
            {
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sets.Add(new QuestionsSet((int)reader["id"], reader["name"].ToString(), reader["scope"].ToString(), reader["author"].ToString(), reader["difficulty"].ToString()));
                    }
                }
            }
            return sets;
        }
    }
}
