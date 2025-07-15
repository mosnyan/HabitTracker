using HabitTracker.Application.DTOs;
using HabitTracker.Domain.Models;
using HabitTracker.Infrastructure.Repositories;

namespace HabitTracker.Domain.Services;

public class OccurrenceService(OccurrenceRepository occurrenceRepo,
                               HabitRepository habitRepo)
{
    public IReadOnlyList<OccurrenceDisplayDto> GetAllOccurrences()
    {
        var occurrences = occurrenceRepo.GetAllOccurrences();
        var habitsDict = habitRepo.GetAllHabits().ToDictionary(habit => habit.Id, habit => habit.Name);

        var occurrencesDtos = occurrences.Select(occ => new OccurrenceDisplayDto(
            occ.Id,
   habitsDict.GetValueOrDefault(occ.HabitId, "unknown"),
            occ.Date)).ToList();

        return occurrencesDtos;
    }

    public IReadOnlyList<OccurrenceDisplayDto> GetOccurrencesForHabit(int id)
    {
        var habit = habitRepo.GetHabitById(id) ?? new Habit(0, "unknown", "unknown");
        var occurrences = occurrenceRepo.GetOccurrencesByHabitId(id);

        var occurrencesDtos = occurrences.Select(occ => new OccurrenceDisplayDto(
            occ.Id,
            habit.Name,
            occ.Date)).ToList();

        return occurrencesDtos;
    }

    public bool CreateOccurrence(OccurrenceCreationDto occurrence)
    {
        var occ = new Occurrence(occurrence.Id, occurrence.Date, occurrence.HabitId);
        return occurrenceRepo.CreateOccurrence(occ);
    }

    public bool DeleteOccurrenceById(int id)
    {
        return occurrenceRepo.DeleteOccurrenceById(id);
    }
}