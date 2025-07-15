using HabitTracker.Models;
using HabitTracker.Repositories;

namespace HabitTracker.Services;

public class HabitService(HabitRepository habitRepo)
{
    public IReadOnlyList<Habit> GetAllHabits()
    {
        return habitRepo.GetAllHabits();
    }

    public Habit? GetHabit(int id)
    {
        return habitRepo.GetHabitById(id);
    }

    public bool CreateHabit(Habit habit)
    {
        return habitRepo.CreateHabit(habit);
    }

    public bool UpdateHabit(Habit habit)
    {
        return habitRepo.UpdateHabit(habit);
    }

    public bool DeleteHabit(int id)
    {
        return habitRepo.DeleteHabitById(id);
    }
}