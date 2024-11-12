namespace CodeInterview;

public class Database()
{
    private int _maxId = 0;
    private Dictionary<int, DatasetEvent> _events = new();
    static readonly HashSet<string> Commands = ["create", "list", "get", "update", "delete", "exit"];
    private const int MAX_STRING_LENGTH = 100;

    public void Create()
    {
        var name = GetInput("Enter new Event Name");
        var location = GetInput("Enter Event Location");
        var date = GetInput("Enter Event Date");
        var description = GetInput("Enter Event Description");
        
        DatasetEvent newEvent = new DatasetEvent(++_maxId, name, date, location, description);
        _events.Add(newEvent.Id, newEvent);
    }
    
    public void List()
    {
        foreach (var eve in _events.Values)
        {
            eve.PrintShort();
        }
    }

    public void Get(string idString)
    {
        var id = TransformId(idString);
        if(!CheckId(id)) return;
        _events[id].PrintLong();
    }

    public void Delete(string idString)
    {
        var id = TransformId(idString);
        if(!CheckId(id)) return;
        
        _events.Remove(id);
    }

    public void Update(string idString)
    {
        var id = TransformId(idString);
        if(!CheckId(id)) return;

        var eve = _events[id];
        
        var name = GetInput("Enter new Event Name (leave empty to keep current)", true);
        var location = GetInput("Enter new Event Location (leave empty to keep current)", true);
        var date = GetInput("Enter new Event Date (leave empty to keep current)", true);
        var description = GetInput("Enter new Event Description (leave empty to keep current)", true);
        
        eve.Name = name != "" ? name: eve.Name;
        eve.Location = location != "" ? location: eve.Location;
        eve.Date = date != "" ? date: eve.Date;
        eve.Description = description != "" ? description: eve.Description;
    }

    private string GetInput(string prompt, bool allowEmpty = false)
    {
        var input = "";
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        } while (CheckStringLength(input, allowEmpty));

        return input;
    }

    private bool CheckId(int id)
    {
        if (!_events.ContainsKey(id))
        {
            Console.WriteLine("Invalid ID");
            return false;
        }
        return true;
    }

    private int TransformId(string idString)
    {
        var id = -1;
        try
        {
            id = Convert.ToInt32(idString);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Input, ID has to be a number.");
        }

        return id;
    }
    
    public void ListCommands()
    {
        Console.WriteLine(string.Join(", ", Commands.ToList()));
    }

    public bool CheckStringLength(string input, bool allowEmpty = false)
    {
        if (input.Length == 0 && !allowEmpty)
        {
            Console.WriteLine("Input can't be empty");
            return true;
        }
        if (input.Length <= MAX_STRING_LENGTH) return false;
        
        
        Console.WriteLine("Input too long");
        return true;
    }
}