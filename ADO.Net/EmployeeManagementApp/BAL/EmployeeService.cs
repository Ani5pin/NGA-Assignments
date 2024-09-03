using System;
using EmployeeManagementApp.DAL;
using EmployeeManagementApp.DTO;

namespace EmployeeManagementApp.BAL
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            ValidateEmployee(employee);
            _repository.AddEmployee(employee);
        }

        private void ValidateEmployee(EmployeeDTO employee)
        {
            if (employee.ID <= 0)
                throw new ArgumentException("Invalid ID");

            if (string.IsNullOrWhiteSpace(employee.Name) || employee.Name.Length < 15 || !System.Text.RegularExpressions.Regex.IsMatch(employee.Name, @"^[a-zA-Z\s]+$"))
                throw new ArgumentException("Name must be at least 15 characters long, contain only letters and spaces");

            if (employee.DateOfBirth > DateTime.Now || employee.DateOfBirth.Year < 2002 || employee.DateOfBirth.Year > 2005)
                throw new ArgumentException("DateOfBirth must be between 2002 and 2005");

            if (employee.DateOfJoining > DateTime.Now)
                throw new ArgumentException("DateOfJoining must be less than or equal to the current date");

            if (employee.Salary.HasValue && (employee.Salary < 12000 || employee.Salary > 60000))
                throw new ArgumentException("Salary must be between 12000 and 60000");

            if (employee.Dept != "HR" && employee.Dept != "Accts" && employee.Dept != "IT")
                throw new ArgumentException("Dept must be one of HR, Accts, IT");

            if (string.IsNullOrWhiteSpace(employee.Password))
                throw new ArgumentException("Password cannot be empty");

            // Implement password hashing if needed
        }
    }
}
