
namespace CSHARP_test;

class Teacher
{
    private static List<Teacher> teachers = new List<Teacher>();

    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> AssignedCourses { get; set; } = new List<string>();

    public void DisplayDetails()
    {
        Console.WriteLine($"Teacher ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Assigned Courses: {string.Join(", ", AssignedCourses)}");
    }

    public static void AddTeacher(string name, List<string> assignedCourses)
    {
        int newId = teachers.Count + 1;
        Teacher newTeacher = new Teacher
        {
            Id = newId,
            Name = name,
            AssignedCourses = assignedCourses
        };

        teachers.Add(newTeacher);
        Console.WriteLine("Teacher added successfully.");
    }

    public static void EditTeacher(int teacherId, string newName)
    {
        Teacher teacherToEdit = teachers.Find(t => t.Id == teacherId);
        if (teacherToEdit != null)
        {
            teacherToEdit.Name = newName;
            Console.WriteLine("Teacher details updated successfully.");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public static void DeleteTeacher(int teacherId)
    {
        Teacher teacherToDelete = teachers.Find(t => t.Id == teacherId);
        if (teacherToDelete != null)
        {
            teachers.Remove(teacherToDelete);
            Console.WriteLine("Teacher deleted successfully.");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public static List<Teacher> SearchTeachers(string keyword)
    {
        return teachers
            .Where(t => t.Name.ToLower().Contains(keyword) || t.Id.ToString().Contains(keyword))
            .ToList();
    }

    public static List<Teacher> GetAllTeachers()
    {
        return teachers;
    }
    public void AssignCourse(string course)
    {
        AssignedCourses.Add(course);
        Console.WriteLine($"Course '{course}' assigned to {Name} (ID: {Id}).");
    }
}