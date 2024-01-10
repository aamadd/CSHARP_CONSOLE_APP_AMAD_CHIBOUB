namespace CSHARP_test;
class Course
{
    public static List<Course> courses = new List<Course>();

    public int CourseID { get; set; }
    public string Name { get; set; }
    public int ModuleID { get; set; } // New property to represent the module to which the course is associated

    public void DisplayDetails()
    {
        Console.WriteLine($"Course ID: {CourseID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Associated Module ID: {ModuleID}");
    }

    public string ReadContentFromFile()
    {
        string filePath = GetCourseFilePath();
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found for course '{Name}'.");
            return null;
        }
    }

    // New method to update course content in file
    public void SaveContentToFile(string newContent)
    {
        try
        {
            string filePath = GetCourseFilePath();
            File.WriteAllText(filePath, newContent);
            Console.WriteLine("Course content updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    // New method to delete course file
    public void DeleteCourseFile()
    {
        string filePath = GetCourseFilePath();
        try
        {
            File.Delete(filePath);
            Console.WriteLine($"Course file for '{Name}' deleted successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found for course '{Name}'.");
        }
    }

    private string GetCourseFilePath()
    {
        // Create a folder named "CourseFiles" if it doesn't exist
        string folderPath = "CourseFiles";
        Directory.CreateDirectory(folderPath);

        // Combine the folder path and course file name
        string filePath = Path.Combine(folderPath, $"{Name}.txt");

        return filePath;
    }

    public static List<Course> GetAllCourses()
    {
        return courses;
    }

    public static void ViewAllCourses()
    {
        List<Course> allCourses = GetAllCourses();
        if (allCourses.Any())
        {
            Console.WriteLine("All Courses:");
            foreach (var course in allCourses)
            {
                course.DisplayDetails();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No courses available.");
        }
    }

    public static void AssociateCourseWithModule(int courseId, int moduleId)
    {
        Course courseToAssociate = courses.Find(c => c.CourseID == courseId);
        if (courseToAssociate != null)
        {
            courseToAssociate.ModuleID = moduleId; // Update the ModuleID property
            Module module = Module.GetAllModules().FirstOrDefault(m => m.ModuleID == moduleId);
            if (module != null)
            {
                module.Courses.Add(courseToAssociate);
                Console.WriteLine("Course associated with module successfully.");

                // Update the AssignedCourses of teachers with the newly associated course
                List<Teacher> teachersToUpdate = Teacher.GetAllTeachers().Where(t => t.AssignedCourses.Contains(courseToAssociate.Name)).ToList();
                foreach (var teacher in teachersToUpdate)
                {
                    teacher.AssignedCourses.Add(courseToAssociate.Name);
                }
            }
            else
            {
                Console.WriteLine("Module not found.");
            }
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    public static void AddCourse(string courseName)
    {
        int newCourseId = courses.Count + 1;
        Course newCourse = new Course
        {
            CourseID = newCourseId,
            Name = courseName,
            ModuleID = 0 // You may initialize it as per your requirements
        };

        courses.Add(newCourse);
        Console.WriteLine($"Course '{courseName}' added successfully.");
    }
}