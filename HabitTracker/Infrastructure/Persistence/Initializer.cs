using Microsoft.Data.Sqlite;

namespace HabitTracker.Infrastructure.Persistence;

public class Initializer(string connectionString)
{

    public void Initialize()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            CreateHabitsTable(connection);
            CreateOccurrencesTable(connection);
        }
    }

    private int CreateHabitsTable(SqliteConnection connection)
    {
        string query = "CREATE TABLE IF NOT EXISTS habits" +
                       "(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                       "name VARCHAR(64)," +
                       "unit VARCHAR(64))";
        var command = new SqliteCommand(query, connection);
        return command.ExecuteNonQuery();
    }

    private int CreateOccurrencesTable(SqliteConnection connection)
    {
        string query = "CREATE TABLE IF NOT EXISTS occurrences" +
                       "(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                       "date VARCHAR(20)," +
                       "habit_id INTEGER," +
                       "FOREIGN KEY(habit_id) REFERENCES habits(id) ON DELETE CASCADE)";
        var command = new SqliteCommand(query, connection);
        return command.ExecuteNonQuery();
    }
}