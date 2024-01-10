namespace CSHARP_test;
class Student
{
    private static List<Student> students = new List<Student>();

    public int Id { get; set; }
    public string Name { get; set; }
    public string CurrentClass { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"Student ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Current Class: {CurrentClass}");

        // Display calendar events relevant to the student's class
        var relevantEvents = Program.GetRelevantCalendarEvents(CurrentClass);
        if (relevantEvents.Count > 0)
        {
            Console.WriteLine("\nUpcoming Calendar Events for this Class:");
            foreach (var calendarEvent in relevantEvents)
            {
                calendarEvent.DisplayDetails();
                Console.WriteLine();
            }
        }
    }

    public static void AddStudent(string name, string currentClass)
    {
        int newId = students.Count + 1;
        Student newStudent = new Student
        {
            Id = newId,
            Name = name,
            CurrentClass = currentClass
        };

        students.Add(newStudent);
        Console.WriteLine("Student added successfully.");
    }

    public static void EditStudent(int studentId, string newName, string newClass)
    {
        try
        {
            Student studentToEdit = students.Find(s => s.Id == studentId);
            if (studentToEdit != null)
            {
                studentToEdit.Name = newName;
                studentToEdit.CurrentClass = newClass;
                Console.WriteLine("Student details updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static void DeleteStudent(int studentId)
    {
        Student studentToDelete = students.Find(s => s.Id == studentId);
        if (studentToDelete != null)
        {
            students.Remove(studentToDelete);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public static List<Student> SearchStudents(string keyword)
    {
        return students
            .Where(s => s.Name.ToLower().Contains(keyword) || s.Id.ToString().Contains(keyword))
            .ToList();
    }
    public static List<Student> GetAllStudents()
    {
        return students;
    }
}