public class Dataset_Event(int id, string name, DateTime date, string location, string description)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime Date { get; set; } = date;
    public string Location { get; set; } = location;
    public string Description { get; set; } = description;
}