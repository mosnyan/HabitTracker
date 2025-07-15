using HabitTracker.Application.DTOs;
using HabitTracker.Domain.Services;

namespace HabitTracker.Application.Services;

public class OccurrenceController(OccurrenceService occurrenceService)
{
    public bool CreateOccurrence(string date, int habitId)
    {
        return occurrenceService.CreateOccurrence(new OccurrenceCreationDto(0, habitId, date));
    }

    public IReadOnlyList<OccurrenceDisplayDto> GetAllOccurrences()
    {
        return occurrenceService.GetAllOccurrences();
    }

    public IReadOnlyList<OccurrenceDisplayDto> GetOccurrencesForHabit(int habitId)
    {
        return occurrenceService.GetOccurrencesForHabit(habitId);
    }

    public bool DeleteOccurrence(int id)
    {
        return occurrenceService.DeleteOccurrenceById(id);
    }
}