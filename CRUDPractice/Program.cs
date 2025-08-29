using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUDPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=TestDB;Trusted_Connection=True;";
            StudentRepository repo = new StudentRepository(connectionString);

            while (true)
            {
                Console.WriteLine("\n--- Student Menu ---");
                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Show All Students");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertStudent(repo);
                        break;

                    case "2":
                        UpdateStudent(repo);
                        break;

                    case "3":
                        DeleteStudent(repo);
                        break;

                    case "4":
                        ShowAllStudents(repo);
                        break;

                    case "5":
                        return; 

                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void InsertStudent(StudentRepository repo)
        {
            Student s = new Student();

            Console.Write("Enter Name: ");
            s.name = Console.ReadLine();

            Console.Write("Enter Family: ");
            s.family = Console.ReadLine();

            Console.Write("Enter Age: ");
            s.age = int.Parse(Console.ReadLine());

            Console.Write("Enter Mark: ");
            s.mark = int.Parse(Console.ReadLine());

            int rows = repo.insert(s);
            Console.WriteLine($"{rows} student(s) inserted successfully.");
        }

        static void UpdateStudent(StudentRepository repo)
        {
            Console.Write("Enter Old Name: ");
            string oldName = Console.ReadLine();

            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();

            int rows = repo.update(oldName, newName);
            Console.WriteLine($"{rows} student(s) updated successfully.");
        }

        static void DeleteStudent(StudentRepository repo)
        {
            Console.Write("Enter Name to Delete: ");
            string name = Console.ReadLine();

            int rows = repo.delete(name);
            Console.WriteLine($"{rows} student(s) deleted successfully.");
        }

        static void ShowAllStudents(StudentRepository repo)
        {
            List<Student> students = repo.GetAll();

            Console.WriteLine("\n--- Student List ---");
            foreach (var s in students)
            {
                Console.WriteLine($"Name: {s.name}, Family: {s.family}, Age: {s.age}, Mark: {s.mark}");
            }
        }
    }
}
