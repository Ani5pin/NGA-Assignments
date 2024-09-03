using System;
using EmployeeManagementApp.BAL;
using EmployeeManagementApp.DTO;

namespace EmployeeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeService service = new EmployeeService();

            while (true)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    try
                    {
                        EmployeeDTO employee = new EmployeeDTO();

                        Console.Write("Enter ID: ");
                        employee.ID = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        employee.Name = Console.ReadLine();

                        Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
                        employee.DateOfBirth = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Date of Joining (yyyy-mm-dd): ");
                        employee.DateOfJoining = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Salary (leave empty if not applicable): ");
                        string salaryInput = Console.ReadLine();
                        employee.Salary = string.IsNullOrEmpty(salaryInput) ? (decimal?)null : decimal.Parse(salaryInput);

                        Console.Write("Enter Department (HR, Accts, IT): ");
                        employee.Dept = Console.ReadLine();

                        Console.Write("Enter Password: ");
                        employee.Password = Console.ReadLine();

                        service.AddEmployee(employee);

                        Console.WriteLine("Employee added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
