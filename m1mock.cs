using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
            foreach (var c in AvailableCourses)
            {
                if(c.Key==code) throw new ArgumentException("Course with this code already exists.");
            }
            var course = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses.Add(code, course);
            throw new NotImplementedException();
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary
            foreach(var r in Students)
            {
                if(r.Key==id)throw new ArgumentException("Student Id already exists");
            }
            var student = new Student(id, name, major, maxCredits, completedCourses);
            Students.Add(id, student);
            throw new NotImplementedException();
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            
            if (!Students.ContainsKey(studentId))
            {
            Console.WriteLine("Student not found.");
            return false;
            }

            if (!AvailableCourses.ContainsKey(courseCode))
            {
            Console.WriteLine("Course not found.");
            return false;
            }

            var student = Students[studentId];
            var course = AvailableCourses[courseCode];

            bool result = student.AddCourse(course);

            if (result)
            Console.WriteLine("Registration successful.");
            else
            Console.WriteLine("Registration failed. Check prerequisites, credit limit, or capacity.");

            return result;


            throw new NotImplementedException();
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            if (!Students.ContainsKey(studentId))
            {
            Console.WriteLine("Student not found.");
            return false;
            }

            var student = Students[studentId];
            bool result = student.DropCourse(courseCode);

            if (result)
            Console.WriteLine("Course dropped successfully.");
            else
            Console.WriteLine("Drop failed. Course not found in student's schedule.");

            return result;
            throw new NotImplementedException();
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            if (!AvailableCourses.Any())
            {
            Console.WriteLine("No courses available.");
            return;
            }

            foreach (var course in AvailableCourses.Values)
            {
            Console.WriteLine($"{course.CourseCode} - {course.CourseName} | " + $"{course.Credits} Credits | " +$"Enrollment: {course.GetEnrollmentInfo()}/{course.MaxCapacity}");
            }
            throw new NotImplementedException();
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if(studentId==null)return;
            Students[studentId].DisplaySchedule();
            throw new NotImplementedException();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            double averageEnrollment = 0;

            if (totalCourses > 0)
            {
            averageEnrollment = AvailableCourses.Values.Average(c => c.GetEnrollmentInfo().Count());
            }
            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Total Courses: {totalCourses}");
            Console.WriteLine($"Average Enrollment per Course: {averageEnrollment:F2}");
            throw new NotImplementedException();
        }
    }
}
namespace University_Course_Registration_System
{
    // =========================
    // Course Class
    // =========================
    public class Course
    {
        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public int Credits { get; private set; }
        public int MaxCapacity { get; private set; }
        public List<string> Prerequisites { get; private set; }

        private int CurrentEnrollment;

        public Course(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            CourseCode = code;
            CourseName = name;
            Credits = credits;
            MaxCapacity = maxCapacity;
            Prerequisites = prerequisites ?? new List<string>();
            CurrentEnrollment = 0;
        }

        public bool IsFull()
        {
            if (CurrentEnrollment >= MaxCapacity)return true;
            return false;
            // TODO: Return true if CurrentEnrollment >= MaxCapacity
            throw new NotImplementedException();
        }

        public bool HasPrerequisites(List<string> completedCourses)
        {
            // TODO: Check if ALL prerequisites exist in completedCourses
            foreach(var s in completedCourses)
            {
                if(!completedCourses.Contains(s))return false;
            }
            return true;
            throw new NotImplementedException();
        }

        public void EnrollStudent()
        {
            // TODO:
            // 1. Throw InvalidOperationException if course is full
            // 2. Otherwise increment CurrentEnrollment
            if(IsFull()){
            throw new NotImplementedException();}
            CurrentEnrollment++;
        }

        public void DropStudent()
        {
            // TODO: Decrement CurrentEnrollment only if greater than zero
            if(CurrentEnrollment>0)CurrentEnrollment--;
            throw new NotImplementedException();
        }

        public string GetEnrollmentInfo()
        {
            return $"{CurrentEnrollment}/{MaxCapacity}";
        }
    }
}

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            // TODO: Return sum of credits of all RegisteredCourses
            int sum=0;
            foreach(Course c in RegisteredCourses)
            {
                sum+=c.Credits;
            }
            return sum;
            throw new NotImplementedException();
        }

        public bool CanAddCourse(Course course)
        {
            // TODO:
            // 1. Course should not already be registered
            // 2. Total credits + course credits <= MaxCredits
            // 3. Course prerequisites must be satisfied
            if(course.Credits+GetTotalCredits()>MaxCredits)return false;
            foreach( var c in RegisteredCourses)
            {
                if(c.CourseCode==course.CourseCode)return false;
            }
            if (!course.HasPrerequisites(CompletedCourses))return false;
            return true;
            throw new NotImplementedException();
        }

        public bool AddCourse(Course course)
        {
            // TODO:
            // 1. Call CanAddCourse
            // 2. Check course capacity
            // 3. Add course to RegisteredCourses
            // 4. Call course.EnrollStudent()
            if(!CanAddCourse(course))return false;
            if(course.IsFull())return false;
            RegisteredCourses.Add(course);
            course.EnrollStudent();
            return true;
            throw new NotImplementedException();
        }

        public bool DropCourse(string courseCode)
        {
            // TODO:
            // 1. Find course by code
            // 2. Remove from RegisteredCourses
            // 3. Call course.DropStudent()
            var course = RegisteredCourses
             .FirstOrDefault(c => c.CourseCode == courseCode);

            if (course == null)
            return false;
            RegisteredCourses.Remove(course);
            course.DropStudent();
            return true;
            throw new NotImplementedException();
        }

        public void DisplaySchedule()
        {
            // TODO:
            // Display course code, name, and credits
            // If no courses registered, display appropriate message
            if (!RegisteredCourses.Any())
            {
            Console.WriteLine("No courses registered.");
            return;
            }

            Console.WriteLine($"Schedule for {Name}:");

            foreach (var course in RegisteredCourses)
        {
            Console.WriteLine($"{course.CourseCode} - {course.CourseName} ({course.Credits} Credits)");
        }

        Console.WriteLine($"Total Credits: {GetTotalCredits()}");
                throw new NotImplementedException();
        }
    }
}

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = (Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case "1":
                        Console.Write("Enter Course Code: ");
                        string code = Console.ReadLine();

                        Console.Write("Enter Course Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Credits: ");
                        int credits = int.Parse(Console.ReadLine());

                        Console.Write("Enter Max Capacity: ");
                        int capacity = int.Parse(Console.ReadLine());

                        system.AddCourse(code, name, credits, capacity);
                        Console.WriteLine("Course added successfully.");
                        break;
                        case "2":
                        Console.Write("Enter Student Id: ");
                        string id=Console.ReadLine();
                        Console.Write("Enter Student Name: ");
                        string sname=Console.ReadLine();
                        Console.Write("Enter Student Major: ");
                        string major=Console.ReadLine();
                        Console.Write("Enter maxcredit: ");
                        int max=Convert.ToInt32(Console.ReadLine());
                        system.AddStudent(id,sname,major,max);
                        Console.WriteLine("Student added successfully.");

                        break;
                        case "3":
                        Console.Write("Enter Student ID: ");
                        string regStudentId = Console.ReadLine();

                        Console.Write("Enter Course Code: ");
                        string regCourseCode = Console.ReadLine();

                        system.RegisterStudentForCourse(regStudentId, regCourseCode);
                        break;

                        case "4":
                        Console.Write("Enter Student ID: ");
                        string dropStudentId = Console.ReadLine();

                        Console.Write("Enter Course Code: ");
                        string dropCourseCode = Console.ReadLine();

                        system.DropStudentFromCourse(dropStudentId, dropCourseCode);
                        break;

                        case "5":
                        system.DisplayAllCourses();
                        break;

                        case "6":
                        Console.Write("Enter Student ID: ");
                        string scheduleId = Console.ReadLine();
                        system.DisplayStudentSchedule(scheduleId);
                        break;

                        case "7":
                        system.DisplaySystemSummary();
                        break;

                        case "8":
                        exit = true;
                        Console.WriteLine("Exiting system...");
                        break;

                    
                        default:
                        break;


                    }
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

