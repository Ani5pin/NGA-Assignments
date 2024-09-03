using System;

namespace ADOAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the student repository
            StudentRepository repository = new StudentRepository();

            // Demonstrate CRUD operations
            ShowMenu(repository);
        }

        private static void ShowMenu(StudentRepository repository)
        {
            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Get Student");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(repository);
                        break;
                    case "2":
                        UpdateStudent(repository);
                        break;
                    case "3":
                        DeleteStudent(repository);
                        break;
                    case "4":
                        GetStudent(repository);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private static void AddStudent(StudentRepository repository)
        {
            Student student = new Student();

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Marks: ");
            student.Marks = int.Parse(Console.ReadLine());

            Console.Write("Enter Batch: ");
            student.Batch = Console.ReadLine();

            Console.Write("Enter Course: ");
            student.Course = Console.ReadLine();

            repository.AddStudent(student);
            Console.WriteLine("Student added successfully.");
        }

        private static void UpdateStudent(StudentRepository repository)
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Student student = repository.GetStudent(id);

            if (student != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                student.Name = string.IsNullOrWhiteSpace(name) ? student.Name : name;

                Console.Write("Enter new Date of Birth (yyyy-mm-dd, leave blank to keep current): ");
                string dob = Console.ReadLine();
                student.DateOfBirth = string.IsNullOrWhiteSpace(dob) ? student.DateOfBirth : DateTime.Parse(dob);

                Console.Write("Enter new Marks (leave blank to keep current): ");
                string marks = Console.ReadLine();
                student.Marks = string.IsNullOrWhiteSpace(marks) ? student.Marks : int.Parse(marks);

                Console.Write("Enter new Batch (leave blank to keep current): ");
                string batch = Console.ReadLine();
                student.Batch = string.IsNullOrWhiteSpace(batch) ? student.Batch : batch;

                Console.Write("Enter new Course (leave blank to keep current): ");
                string course = Console.ReadLine();
                student.Course = string.IsNullOrWhiteSpace(course) ? student.Course : course;

                repository.UpdateStudent(student);
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private static void DeleteStudent(StudentRepository repository)
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            repository.DeleteStudent(id);
            Console.WriteLine("Student deleted successfully.");
        }

        private static void GetStudent(StudentRepository repository)
        {
            Console.Write("Enter Student ID to retrieve: ");
            int id = int.Parse(Console.ReadLine());

            Student student = repository.GetStudent(id);

            if (student != null)
            {
                Console.WriteLine($"ID: {student.ID}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Batch: {student.Batch}");
                Console.WriteLine($"Course: {student.Course}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
