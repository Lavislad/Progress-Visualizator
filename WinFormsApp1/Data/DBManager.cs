using Microsoft.Data.Sqlite;

namespace ProgressVisualizer.Data
{
    public class DBManager
    {
        private readonly string connectionString;

        public DBManager(string databasePath)
        {
            connectionString = $"Data Source={databasePath}";

            InitializeDatabase();
        }

        public SqliteConnection GetConnection()
        {
            var connection =
                new SqliteConnection(connectionString);

            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText =
                "PRAGMA foreign_keys = ON;";

            command.ExecuteNonQuery();

            return connection;
        }

        private void InitializeDatabase()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Charts
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Description TEXT,
                    XAxisName TEXT NOT NULL,
                    XAxisType TEXT NOT NULL
                        CHECK (XAxisType IN ('Number', 'Text', 'Date')),
                    YAxisName TEXT NOT NULL,
                    YAxisUnit TEXT,
                    CreatedDate TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS DataPoints
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ChartId INTEGER NOT NULL,
                    XValue TEXT NOT NULL,
                    YValue REAL NOT NULL,

                    FOREIGN KEY (ChartId)
                        REFERENCES Charts(Id)
                        ON DELETE CASCADE
                );
            ";

            command.ExecuteNonQuery();
        }
    }
}