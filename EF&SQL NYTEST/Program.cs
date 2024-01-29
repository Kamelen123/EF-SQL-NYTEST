using EF_SQL_NYTEST.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF_SQL_NYTEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using GymnasieskolaDbContect context = new GymnasieskolaDbContect();
            MainMenu(context);
            
        }
        private static void MainMenu(GymnasieskolaDbContect context)
        {
            
            bool programRunning = false;
            while (!programRunning)
            {
                Console.WriteLine("Option [1] Retreive all students from DataBase");
                Console.WriteLine("Option [2] Retreive all students from a specific class");
                Console.WriteLine("Option [3] Add Employee to DataBase");
                Console.WriteLine("Option [4] Exit Program");
                Console.WriteLine("Choose an option from the menu...");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        RetreiveStudents(context);
                        break;
                    case "2":
                        RetreiveStudentByClass(context);
                        break; 
                    case "3":
                        AddEmployye(context);
                        break;
                    case "4":
                        programRunning = true;
                        break;
                    case "5":
                        //SnittBetyg(context);
                        break;
                }
            }
        }
        private static void SnittBetyg(GymnasieskolaDbContect context)
        {
            var courseGrades = context.vWSnittbetyg.ToList();

            foreach (var courseGrade in courseGrades)
            {
                Console.WriteLine($"Course: {courseGrade.Course}");
                Console.WriteLine($"Average Grade: {courseGrade.Average_Grade}");
                Console.WriteLine($"Max Grade: {courseGrade.Max_Grade}");
                Console.WriteLine($"Min Grade: {courseGrade.Min_Grade}");
                Console.WriteLine("-----------------------------");
            }
        }
        
        private static void RetreiveStudents(GymnasieskolaDbContect context)
        {
            var allStudents = context.TblStudents.ToList();

            Console.WriteLine("Sort by:");
            Console.WriteLine("1. First Name (Ascending)");
            Console.WriteLine("2. First Name (Descending)");
            Console.WriteLine("3. Last Name (Ascending)");
            Console.WriteLine("4. Last Name (Descending)");
            Console.Write("Enter your choice (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        allStudents = allStudents.OrderBy(s => s.FirstName).ToList();
                        break;
                    case 2:
                        allStudents = allStudents.OrderByDescending(s => s.FirstName).ToList();
                        break;
                    case 3:
                        allStudents = allStudents.OrderBy(s => s.LastName).ToList();
                        break;
                    case 4:
                        allStudents = allStudents.OrderByDescending(s => s.LastName).ToList();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Default sorting order will be used.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Default sorting order will be used.");
            }

            foreach (var student in allStudents)
            {
                Console.WriteLine($"Name : {student.FirstName} {student.LastName}");
                Console.WriteLine($"ID : {student.StudentId}");
                Console.WriteLine($"Personnummer : {student.Personnummer}");
                Console.WriteLine($"Age : {student.Age}");
                Console.WriteLine($"Class : {student.Class}");
                Console.WriteLine("------------------------------------");
            }
        }
        private static void AddEmployye(GymnasieskolaDbContect context)
        {
            Console.WriteLine("Enter employee details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Middle Name: ");
            string middleName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            string position = "";
            bool correctOption = false;
            while (!correctOption)
            {
                Console.WriteLine("Enter position from the menu...");
                Thread.Sleep(1000);
                Console.WriteLine("[1] Teacher");
                Console.WriteLine("[2] Janitor");
                Console.WriteLine("[3] Lunchlady");
                Console.WriteLine("[4] Administrator");
                Console.Write("Select between (1-4): ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        position = "Teacher";
                        correctOption = true;
                        break; 
                    case "2":
                        position = "Janitor";
                        correctOption = true;
                        break; 
                    case "3":
                        position = "Lunchlady";
                        correctOption = true;
                        break; 
                    case "4":
                        position = "Administrator";
                        correctOption = true;
                        break;
                        default: Console.WriteLine("Please enter a valid option");
                        break;
                }

            }

            Console.Write("Age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                TblEmployee newEmployee = new TblEmployee
                {
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Age = age,
                    Position = position
                };

                context.TblEmployees.Add(newEmployee);

                context.SaveChanges();

                Console.WriteLine("Employee added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid age input.");
            }
        }
        private static void RetreiveStudentByClass(GymnasieskolaDbContect context)
        {
            var distinctClasses = context.TblStudents.Select(s => s.Class).Distinct();
            Console.WriteLine(" Select from one of these classes");
            foreach (var className in distinctClasses)
            {
                Console.WriteLine($"Class : {className}");
                Console.WriteLine("-----------------------");
            }
            var selectedClass = Console.ReadLine().ToUpper();
            var students = context.TblStudents.Where(s => s.Class == selectedClass).OrderBy(s => s.FirstName);

            foreach (TblStudent s in students)
            {
                Console.WriteLine($"Name : {s.FirstName} {s.LastName}");
                Console.WriteLine($"ID : {s.StudentId}");
                Console.WriteLine($"Class : {s.Class}");
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
