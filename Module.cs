namespace CSHARP_test;
class Module
{
    private static List<Module> modules = new List<Module>();

    public int ModuleID { get; set; }
    public string Name { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public void DisplayDetails()
    {
        Console.WriteLine($"Module ID: {ModuleID}");
        Console.WriteLine($"Name: {Name}");
    }

    public static void CreateModule(string name)
    {
        int newId = modules.Count + 1;
        Module newModule = new Module
        {
            ModuleID = newId,
            Name = name
        };

        modules.Add(newModule);
        Console.WriteLine("Module created successfully.");
    }

    public static void UpdateModule(int moduleId, string newName)
    {
        Module moduleToEdit = modules.Find(m => m.ModuleID == moduleId);
        if (moduleToEdit != null)
        {
            moduleToEdit.Name = newName;
            Console.WriteLine("Module details updated successfully.");
        }
        else
        {
            Console.WriteLine("Module not found.");
        }
    }

    public static void DeleteModule(int moduleId)
    {
        Module moduleToDelete = modules.Find(m => m.ModuleID == moduleId);
        if (moduleToDelete != null)
        {
            modules.Remove(moduleToDelete);
            Console.WriteLine("Module deleted successfully.");
        }
        else
        {
            Console.WriteLine("Module not found.");
        }
    }

    public static void ListModuleCourses(int moduleId)
    {
        Module moduleToDisplay = modules.Find(m => m.ModuleID == moduleId);
        if (moduleToDisplay != null)
        {
            Console.WriteLine($"Courses in Module '{moduleToDisplay.Name}':");
            foreach (var course in moduleToDisplay.Courses)
            {
                course.DisplayDetails();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Module not found.");
        }
    }

    public static List<Module> GetAllModules()
    {
        return modules;
    }

    public static void ViewAllModules()
    {
        List<Module> allModules = GetAllModules();
        if (allModules.Any())
        {
            Console.WriteLine("All Modules:");
            foreach (var module in allModules)
            {
                module.DisplayDetails();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No modules available.");
        }
    }
}