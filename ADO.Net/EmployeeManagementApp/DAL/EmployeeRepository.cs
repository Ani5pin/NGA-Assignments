using System;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagementApp.DTO;

namespace EmployeeManagementApp.DAL
{
    public class EmployeeRepository
    {
        private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeDb;TrustServerCertificate=True;";

        public void AddEmployee(EmployeeDTO employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO Employee (ID, Name, DateOfBirth, DateOfJoining, Salary, Dept, Password)
                    VALUES (@ID, @Name, @DateOfBirth, @DateOfJoining, @Salary, @Dept, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    command.Parameters.AddWithValue("@Salary", (object)employee.Salary ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Dept", employee.Dept);
                    command.Parameters.AddWithValue("@Password", employee.Password); // Store hashed password if required

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Implement other CRUD methods: UpdateEmployee, DeleteEmployee, GetEmployee
    }
}
