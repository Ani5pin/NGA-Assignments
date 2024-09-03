using System;
using System.Data.SqlClient;
using System.Configuration;

public class StudentRepository
{
    private string connectionString = ConfigurationManager.ConnectionStrings["PracticeDb"].ConnectionString;

    public EMail Email { get; internal set; }

    public void AddStudent(Student student)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Student (Name, DateOfBirth, Marks, Batch, Course) VALUES (@Name, @DateOfBirth, @Marks, @Batch, @Course)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);
                cmd.Parameters.AddWithValue("@Batch", student.Batch);
                cmd.Parameters.AddWithValue("@Course", student.Course);

                cmd.ExecuteNonQuery();
            }
        }

        // Send email
        EMail email = new EMail();
        email.SendMail(student);
    }

    public void UpdateStudent(Student student)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE Student SET Name = @Name, DateOfBirth = @DateOfBirth, Marks = @Marks, Batch = @Batch, Course = @Course WHERE ID = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", student.ID);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);
                cmd.Parameters.AddWithValue("@Batch", student.Batch);
                cmd.Parameters.AddWithValue("@Course", student.Course);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteStudent(int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM Student WHERE ID = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Student GetStudent(int id)
    {
        Student student = null;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Student WHERE ID = @ID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        student = new Student
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Marks = Convert.ToInt32(reader["Marks"]),
                            Batch = reader["Batch"].ToString(),
                            Course = reader["Course"].ToString()
                        };
                    }
                }
            }
        }

        return student;
    }

    public int GetStudentCount()
    {
        int count = 0;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM Student";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                count = (int)cmd.ExecuteScalar();
            }
        }

        return count;
    }
}
