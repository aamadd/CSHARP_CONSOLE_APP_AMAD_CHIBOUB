namespace CSHARP_test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("******** Menu ********");
                Console.WriteLine("* 1. Manage Students *");
                Console.WriteLine("* 2. Manage Teachers *");
                Console.WriteLine("* 3. Manage Courses  *");
                Console.WriteLine("* 4. Manage Modules  *");
                Console.WriteLine("* 5. Manage Calendar *");
                Console.WriteLine("*       6. Exit      *");
                Console.WriteLine("  ******************* ");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageStudents();
                        break;
                    case "2":
                        ManageTeachers();
                        break;
                    case "3":
                        ManageCourses();
                        break;
                    case "4":
                        ManageModules();
                        break;
                    case "5":
                        ManageCalendar();
                        break;
                    case "6":
                        Console.WriteLine("_____Exiting program. Goodbye!____");
                        return;
                    default:
                        Console.WriteLine("**Invalid choice. Please enter a number between 1 and 5.**");
                        break;
                }

                Console.WriteLine();
            }
        }


        static void ManageStudents()
        {
            while (true)
            {
                Console.WriteLine("\n******** Student Management Menu ********");
                Console.WriteLine("*            1. Add Student              *");
                Console.WriteLine("*            2. Edit Student             *");
                Console.WriteLine("*            3. Delete Student           *");
                Console.WriteLine("*            4. Search Students          *");
                Console.WriteLine("*            5. View All Students        *");
                Console.WriteLine("*            6. Back to Main Menu        *");
                Console.WriteLine("******************************************");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter student name: ");
                        string studentName = Console.ReadLine();
                        Console.Write("\nEnter current class: ");
                        string currentClass = Console.ReadLine();
                        Student.AddStudent(studentName, currentClass);
                        break;
                    case "2":
                        Console.Write("\nEnter student ID to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int studentId))
                        {
                            Console.Write("\nEnter new name: ");
                            string newName = Console.ReadLine();
                            Console.Write("\nEnter new class: ");
                            string newClass = Console.ReadLine();
                            Student.EditStudent(studentId, newName, newClass);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid student ID. Please enter a valid number.");
                        }
                        break;
                    case "3":
                        Console.Write("\nEnter student ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int studentIdToDelete))
                        {
                            Student.DeleteStudent(studentIdToDelete);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid student ID. Please enter a valid number.");
                        }
                        break;
                    case "4":
                        Console.Write("\nEnter search keyword: ");
                        string keyword = Console.ReadLine();
                        var searchResults = Student.SearchStudents(keyword);
                        DisplayStudentList(searchResults);
                        break;
                    case "5":
                        var allStudents = Student.GetAllStudents();
                        DisplayStudentList(allStudents);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        static void DisplayStudentList(List<Student> students)
        {
            if (students.Count > 0)
            {
                Console.WriteLine("\n\nAll Students:");
                foreach (var student in students)
                {
                    student.DisplayDetails();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\nNo students available.");
            }
        }

        static void ManageTeachers()
        {
            while (true)
            {
                Console.WriteLine("\n***** Teacher Management Menu ******");
                Console.WriteLine("*          1. Add Teacher            *");
                Console.WriteLine("*          2. Edit Teacher           *");
                Console.WriteLine("*          3. Delete Teacher         *");
                Console.WriteLine("*          4. Search Teachers        *");
                Console.WriteLine("*          5. View All Teachers      *");
                Console.WriteLine("*      6. Assign Course to Teacher   *");
                Console.WriteLine("*        7. Back to Main Menu        *");
                Console.WriteLine(" **************************************");
                Console.Write("Enter your choice (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter teacher name: ");
                        string teacherName = Console.ReadLine();
                        Teacher.AddTeacher(teacherName, new List<string>());
                        break;
                    case "2":
                        Console.Write("\nEnter teacher ID to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int teacherId))
                        {
                            Console.Write("\nEnter new name: ");
                            string newName = Console.ReadLine();
                            Teacher.EditTeacher(teacherId, newName);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid teacher ID. Please enter a valid number.");
                        }
                        break;
                    case "3":
                        Console.Write("\nEnter teacher ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int teacherIdToDelete))
                        {
                            Teacher.DeleteTeacher(teacherIdToDelete);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid teacher ID. Please enter a valid number.");
                        }
                        break;
                    case "4":
                        Console.Write("\nEnter search keyword: ");
                        string keyword = Console.ReadLine();
                        var searchResults = Teacher.SearchTeachers(keyword);
                        DisplayTeacherList(searchResults);
                        break;
                    case "5":
                        var allTeachers = Teacher.GetAllTeachers();
                        DisplayTeacherList(allTeachers);
                        break;
                    case "6":
                        if (Course.GetAllCourses().Count == 0)
                        {
                            Console.WriteLine("\nNo courses found. Please create courses before assigning to teachers.");
                        }
                        else
                        {
                            Console.Write("\nEnter teacher ID to assign course: ");
                            if (int.TryParse(Console.ReadLine(), out int teacherIdToAssign))
                            {
                                Teacher teacherToAssign = Teacher.GetAllTeachers().FirstOrDefault(t => t.Id == teacherIdToAssign);
                                if (teacherToAssign != null)
                                {
                                    Console.Write("\nEnter course name to assign: ");
                                    string courseToAssign = Console.ReadLine();

                                    // Check if the course exists
                                    Course course = Course.GetAllCourses().FirstOrDefault(c => c.Name == courseToAssign);
                                    if (course != null)
                                    {
                                        teacherToAssign.AssignCourse(courseToAssign);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\nCourse '{courseToAssign}' does not exist. Please choose a valid course.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nTeacher not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid teacher ID. Please enter a valid number.");
                            }
                        }
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }

        static void DisplayTeacherList(List<Teacher> teachers)
        {
            if (teachers.Count > 0)
            {
                Console.WriteLine("\n\nAll Teachers:");
                foreach (var teacher in teachers)
                {
                    teacher.DisplayDetails();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\nNo teachers available.");
            }
        }

        static void ManageCourses()
        {
            while (true)
            {
                Console.WriteLine("\n******* Course Management Menu *******");
                Console.WriteLine("*           1. Add Course              *");
                Console.WriteLine("* 2. Read/Update/Delete Course Content *");
                Console.WriteLine("*        3. View All Courses            *");
                Console.WriteLine("*     4. Associate Course with Module   *");
                Console.WriteLine("*          5. Back to Main Menu         *");
                Console.WriteLine("*****************************************");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter course name: ");
                        string courseName = Console.ReadLine();
                        Course.AddCourse(courseName);
                        break;

                    case "2":
                        ManageCourseContent();
                        break;

                    case "3":
                        Course.ViewAllCourses();
                        break;

                    case "4":
                        if (Module.GetAllModules().Count == 0)
                        {
                            Console.WriteLine("\nNo modules found. Please create modules before associating courses.");
                        }
                        else
                        {
                            Console.Write("\nEnter course ID to associate: ");
                            if (int.TryParse(Console.ReadLine(), out int courseIDToAssociate))
                            {
                                Console.Write("\nEnter module ID to associate: ");
                                if (int.TryParse(Console.ReadLine(), out int moduleIDToAssociate))
                                {
                                    Course.AssociateCourseWithModule(courseIDToAssociate, moduleIDToAssociate);
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid module ID. Please enter a valid number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid course ID. Please enter a valid number.");
                            }
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        static void ManageCourseContent()
        {
            try
            {
                Console.Write("\nEnter course name: ");
                string courseName = Console.ReadLine();

                Course course = Course.GetAllCourses().FirstOrDefault(c => c.Name == courseName);

                if (course == null)
                {
                    Console.WriteLine($"\nCourse '{courseName}' not found.");
                    return;
                }

                Console.WriteLine("\n**** Course Content Management Menu ****");
                Console.WriteLine("*       1. Read Course Content           *");
                Console.WriteLine("*       2. Update Course Content         *");
                Console.WriteLine("*       3. Delete Course Content         *");
                Console.WriteLine("*    4. Back to Course Management Menu   *");
                Console.WriteLine("******************************************");
                Console.Write("Enter your choice (1-4): ");

                string contentChoice = Console.ReadLine();

                switch (contentChoice)
                {
                    case "1":
                        string content = course.ReadContentFromFile();
                        if (content != null)
                        {
                            Console.WriteLine("\nCourse Content:");
                            Console.WriteLine(content);
                        }
                        break;

                    case "2":
                        Console.Write("\nEnter new content: ");
                        string newContent = Console.ReadLine();
                        course.SaveContentToFile(newContent);
                        break;

                    case "3":
                        course.DeleteCourseFile();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ManageModules()
        {
            while (true)
            {
                Console.WriteLine("\n***** Module Management Menu *****");
                Console.WriteLine("*          1. Create Module        *");
                Console.WriteLine("*          2. Update Module        *");
                Console.WriteLine("*          3. Delete Module        *");
                Console.WriteLine("*        4. List Module Courses    *");
                Console.WriteLine("*        5. View All Modules       *");
                Console.WriteLine("*       6. Back to Main Menu       *");
                Console.WriteLine("************************************");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter module name: ");
                        string moduleName = Console.ReadLine();
                        Module.CreateModule(moduleName);
                        break;
                    case "2":
                        Console.Write("\nEnter module ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int moduleID))
                        {
                            Console.Write("\nEnter new name: ");
                            string newName = Console.ReadLine();
                            Module.UpdateModule(moduleID, newName);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid module ID. Please enter a valid number.");
                        }
                        break;
                    case "3":
                        Console.Write("\nEnter module ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int moduleIDToDelete))
                        {
                            Module.DeleteModule(moduleIDToDelete);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid module ID. Please enter a valid number.");
                        }
                        break;
                    case "4":
                        Console.Write("\nEnter module ID to list courses: ");
                        if (int.TryParse(Console.ReadLine(), out int moduleIDToList))
                        {
                            Module.ListModuleCourses(moduleIDToList);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid module ID. Please enter a valid number.");
                        }
                        break;
                    case "5":
                        Module.ViewAllModules();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
        private static List<CalendarEvent> calendarEvents = new List<CalendarEvent>();

        // ... (Existing code)

        static void ManageCalendar()
        {
            while (true)
            {
                Console.WriteLine("\n******* Calendar Management Menu *****");
                Console.WriteLine("*           1. Add Event               *");
                Console.WriteLine("*           2. Update Event            *");
                Console.WriteLine("*           3. Delete Event            *");
                Console.WriteLine("*           4. View All Events         *");
                Console.WriteLine("*          5. Back to Main Menu        *");
                Console.WriteLine("****************************************");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCalendarEvent();
                        break;
                    case "2":
                        UpdateCalendarEvent();
                        break;
                    case "3":
                        DeleteCalendarEvent();
                        break;
                    case "4":
                        ViewAllCalendarEvents();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        static void AddCalendarEvent()
        {
            Console.Write("\nEnter event title: ");
            string title = Console.ReadLine();

            Console.Write("\nEnter event date (YYYY-MM-DD HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
            {
                Console.Write("\nEnter assigned class: ");
                string assignedClass = Console.ReadLine();

                CalendarEvent newEvent = new CalendarEvent
                {
                    Title = title,
                    Date = eventDate,
                    AssignedClass = assignedClass
                };

                calendarEvents.Add(newEvent);
                Console.WriteLine("\n\nEvent added to the calendar successfully.");
            }
            else
            {
                Console.WriteLine("\n\nInvalid date format. Please enter the date in the correct format.");
            }
        }

        static void ViewAllCalendarEvents()
        {
            if (calendarEvents.Count > 0)
            {
                Console.WriteLine("\n\nAll Calendar Events:");
                foreach (var calendarEvent in calendarEvents)
                {
                    calendarEvent.DisplayDetails();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\n\nNo calendar events available.");
            }
        }
        public static List<CalendarEvent> GetRelevantCalendarEvents(string currentClass)
        {
            return calendarEvents.Where(e => e.AssignedClass == currentClass && e.Date >= DateTime.Now).ToList();
        }
        static void UpdateCalendarEvent()
        {
            Console.Write("\nEnter the title of the event to update: ");
            string titleToUpdate = Console.ReadLine();

            CalendarEvent eventToUpdate = calendarEvents.Find(e => e.Title == titleToUpdate);

            if (eventToUpdate != null)
            {
                Console.Write("\nEnter updated event title: ");
                eventToUpdate.Title = Console.ReadLine();

                Console.Write("\nEnter updated event date (YYYY-MM-DD HH:mm): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime updatedEventDate))
                {
                    eventToUpdate.Date = updatedEventDate;
                    Console.WriteLine("\n\nEvent updated successfully.");
                }
                else
                {
                    Console.WriteLine("\n\nInvalid date format. Event not updated.");
                }
            }
            else
            {
                Console.WriteLine($"\n\nEvent with title '{titleToUpdate}' not found.");
            }
        }

        static void DeleteCalendarEvent()
        {
            Console.Write("\nEnter the title of the event to delete: ");
            string titleToDelete = Console.ReadLine();

            CalendarEvent eventToDelete = calendarEvents.Find(e => e.Title == titleToDelete);

            if (eventToDelete != null)
            {
                calendarEvents.Remove(eventToDelete);
                Console.WriteLine("\nEvent deleted successfully.");
            }
            else
            {
                Console.WriteLine($"\n\nEvent with title '{titleToDelete}' not found.");
            }
        }
    }
}