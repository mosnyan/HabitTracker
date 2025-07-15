using HabitTracker.Models;
using HabitTracker.Services;

namespace HabitTracker.Controllers;

public class HabitController(HabitService habitService)
{
    public bool CreateHabit(string name, string unit)
    {
        return habitService.CreateHabit(new Habit(0, name, unit));
    }

    public IReadOnlyList<Habit> ReadAllHabits()
    {
        return habitService.GetAllHabits();
    }

    public bool UpdateHabit(int id, string name, string unit)
    {
        return habitService.UpdateHabit(new Habit(id, name, unit));
    }

    public bool DeleteHabit(int id)
    {
        return habitService.DeleteHabit(id);
    }
}