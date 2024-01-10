class CalendarEvent
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string AssignedClass { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"AssignedClass: {AssignedClass}");
    }
}