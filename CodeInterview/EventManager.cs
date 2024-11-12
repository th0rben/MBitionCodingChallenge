using CodeInterview;

public class EventManager
{
    private Dictionary<int, DatasetEvent> _events = new Dictionary<int, DatasetEvent>();
    private Database _db = new Database();

    public void Run()
    {
        string? input = null;
        var continueLoop = true;
        
        while (continueLoop)
        {
            _db.ListCommands();
            input = GetInput();
            continueLoop = ExecuteInput(input);
        }
    }

    private bool ExecuteInput(string? input)
    {
        if (input != null) return RunCommand(input.Split());
        
        Console.WriteLine("No input provided");
        return true;

    }
    
    private bool RunCommand(string[] inputArray)
    {
        switch (inputArray[0])
        {
            case "create":
                _db.Create();
                break;
            case "list":
                _db.List();
                break;
            case "get":
                if(CheckInput(inputArray))
                    _db.Get(inputArray[1]);
                break;
            case "update":
                if(CheckInput(inputArray))
                    _db.Update(inputArray[1]);
                break;
            case "delete":
                if(CheckInput(inputArray))
                    _db.Delete(inputArray[1]);
                break;
            case "exit":
                return false;
            default:
                Console.WriteLine("Unknown command");
                break;
        }
        return true;
    }

    private bool CheckInput(string[] inputArray)
    {
        if (inputArray.Length > 1) return true;
        Console.WriteLine("No ID provided");
        return false;
    }
        
    private static string? GetInput()
    {
        Console.WriteLine("Please enter a command: ");
        return Console.ReadLine();
    }
}
