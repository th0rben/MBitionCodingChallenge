using System.Diagnostics;

public class DatasetEvent(int id, string name, string date, string location, string description)
{
    public int Id { get; } = id;
    public string Name { get; set; } = name;
    public string Date { get; set; } = date;
    public string Location { get; set; } = location;
    public string Description { get; set; } = description;

    public void PrintShort()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Location: {Location}, Date: {Date}");
    }

    public void PrintLong()
    {
        Console.WriteLine("Event Details:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine($"Description: {Description}");
    }
}
