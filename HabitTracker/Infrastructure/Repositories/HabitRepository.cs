using HabitTracker.Domain.Models;
using Microsoft.Data.Sqlite;

namespace HabitTracker.Infrastructure.Repositories;

public class HabitRepository(string connectionString)
{
    public IReadOnlyList<Habit> GetAllHabits()
    {
        List<Habit> habits = [];
        
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM habits";
            var command = new SqliteCommand(query, connection);
            var response = command.ExecuteReader();
            
            while (response.Read())
            {
                habits.Add(new Habit(response.GetInt32(0),
                                  response.GetString(1),
                                    response.GetString(2)
                                  )
                );
            }  
        }
        return habits;
    }

    public Habit? GetHabitById(int id)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT id, name, unit FROM habits WHERE id = @id";
            SqliteCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);
            var response = command.ExecuteReader();

            if (response.Read())
            { 
                Habit habit = new(response.GetInt32(0),
                               response.GetString(1),
                                 response.GetString(2)
                               );
                return habit;
            }
            return null;
        }
    }

    public bool CreateHabit(Habit habit)
    {
        var success = 0;
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO habits (name, unit) VALUES (@name, @unit)";
            SqliteCommand command = new(query, connection);
            command.Parameters.AddWithValue("@name", habit.Name);
            command.Parameters.AddWithValue("@unit", habit.Unit);
            success = command.ExecuteNonQuery();
        }
        return success > 0;
    }

    public bool UpdateHabit(Habit habit)
    {
        var success = 0;
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE habits SET name = @name, unit = @unit WHERE id = @id";
            SqliteCommand command = new(query, connection);
            command.Parameters.AddWithValue("@name", habit.Name);
            command.Parameters.AddWithValue("@unit", habit.Unit);
            command.Parameters.AddWithValue("@id", habit.Id);
            success = command.ExecuteNonQuery();
        }

        return success > 0;
    }

    public bool DeleteHabitById(int id)
    {
        var success = 0;
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM habits WHERE id = @id";
            SqliteCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);
            success = command.ExecuteNonQuery();
        }

        return success > 0;
    }
}