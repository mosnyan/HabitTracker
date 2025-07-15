using HabitTracker.Models;

namespace HabitTracker;

public class View
{

    public int GetMainSelection()
    {
        DisplayBanner();
        DisplayMainMenu();
        DisplayFunctionSelectReqs();
        return GetUserFunctionChoice();
    }
    
    private void DisplayBanner()
    {
        Console.WriteLine("<><><> Habit Tracking App <><><><><><><><><><><><><><><>\n");
    }
    
    private void DisplayMainMenu()
    {
        Console.WriteLine("1. Create a new habit.");
        Console.WriteLine("2. Add an occurrence to a habit.");
        Console.WriteLine("3. Update a habit.");
        Console.WriteLine("4. Delete a habit.");
        Console.WriteLine("5. Quit the application.");
    }

    private void DisplayFunctionSelectReqs()
    {
        Console.Write("\nPlease select a function:");
    }

    private int GetUserFunctionChoice()
    {
        do
        {
            var success = Int32.TryParse(Console.ReadLine(), out var selection);
            if (!success)
            {
                Console.WriteLine("Please input a valid number.");
                DisplayFunctionSelectReqs();
            }
            else if (!Enumerable.Range(1, 3).Contains(selection))
            {
                Console.WriteLine("Please input a number between 1 and 5.");
                DisplayFunctionSelectReqs();
            }
            else
            {
                return selection;
            }
        } while (true);
    }
    
    public void DisplayFunctionHeader(int function)
    {
        switch (function)
        {
            case 1:
                Console.WriteLine("<><><> Habit Creation <><><><><><><><><><><><><><><>");
                break;
            case 2:
                Console.WriteLine("<><><> Add Occurrence <><><><><><><><><><><><><><><>");
                break;
            case 3:
                Console.WriteLine("<><><> Habit Update   <><><><><><><><><><><><><><><>");
                break;
            case 4:
                Console.WriteLine("<><><> Delete Habit   <><><><><><><><><><><><><><><>");
                break;
            case 5:
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
    
    private void DisplayHabits(IReadOnlyCollection<Habit> habits)
    {
        foreach (var habit in habits)
        {
            Console.WriteLine($"{habit.Id}. {habit.Name}");
        }
    }

    public string GetNewHabitName()
    {
        DisplayHabitSelectionReqs();
        return GetNewUserHabit();
    }
    
    private void DisplayHabitCreationReqs()
    {
        Console.Write("\nType the name of the habit you wish to create: ");
    }

    private string GetNewUserHabit()
    {
        string? name;
        do
        {
            name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("The habit name cannot be null.");
                DisplayHabitCreationReqs();
            }
        } while (name == null);

        return name;
    }

    public void DisplayNewHabitSuccess()
    {
        Console.WriteLine("Habit successfully added!");
    }

    public int GetHabitSelection(IReadOnlyCollection<Habit> habits)
    {
        DisplayHabitSelectionReqs();
        return GetHabitId(habits);
    }

    private void DisplayHabitSelectionReqs()
    {
        Console.Write("\nPlease enter the number of the habit you wish to select: ");
    }

    private int GetHabitId(IReadOnlyCollection<Habit> habits)
    {
        do
        {
            var success = Int32.TryParse(Console.ReadLine(), out var selection);
            if (!success)
            {
                Console.WriteLine("Please input a valid number.");
                DisplayHabitSelectionReqs();
            }
            else if (!Enumerable.Range(1, habits.Count).Contains(selection))
            {
                Console.WriteLine($"Please input a number between 1 and {habits.Count}.");
                DisplayHabitSelectionReqs();
            }
            else
            {
                return selection;
            }
        } while (true);
    }

    public string GetNewOccurrenceDate()
    {
        DisplayOccurrenceCreationReqs();
        return GetOccurrenceDate();
    }

    private void DisplayOccurrenceCreationReqs()
    {
        Console.Write("\nPlease input the date of this occurrence: ");
    }

    private string GetOccurrenceDate()
    {
        string? date;
        do
        {
            date = Console.ReadLine();
            if (date == null)
            {
                Console.WriteLine("The occurrence date cannot be null.");
                DisplayHabitCreationReqs();
            }
        } while (date == null);

        return date;
    }

    public void DisplayOccurrenceCreationStatus(bool success)
    {
        if (success)
        {
            Console.WriteLine("Occurrence successfully added!");
        }
        else
        {
            Console.WriteLine("Occurrence was not added successfully!");
        }
    }

    public int GetHabitToUpdate(IReadOnlyCollection<Habit> habits)
    {
        DisplayHabitUpdateSelReqs();
        return GetHabitId(habits);
    }

    private void DisplayHabitUpdateSelReqs()
    {
        Console.Write("\nEnter the number of the habit you wish to modify: ");
    }

    public (string?, string?) GetUpdatedHabit(Habit habit)
    {
        DisplayHabitUpdateReqs(habit);
        return (PromptUserForNewName(), PromptUserForNewUnit());
    }
    
    private void DisplayHabitUpdateReqs(Habit habit)
    {
        Console.WriteLine($"Current habit name: {habit.Name}");
        Console.WriteLine($"Current habit measuring unit: {habit.Unit}");
        Console.WriteLine("Enter new values when prompted, or press Ctrl+Z to skip.");
    }

    private string? PromptUserForNewName()
    {
        Console.Write("\nEnter a new name for the habit: ");
        return Console.ReadLine();
    }
    
    private string? PromptUserForNewUnit()
    {
        Console.Write("\nEnter a new unit for the habit: ");
        return Console.ReadLine();
    }

    private void DisplayHabitUpdateSuccess(bool success)
    {
        if (success)
        {
            Console.WriteLine("Habit successfully updated!");
        }
        else
        {
            Console.WriteLine("Habit was not updated successfully!");
        }
    }

    private void DisplayHabitDeleteReqs()
    {
        Console.Write("\nEnter a new unit for the habit: ");
    }
}