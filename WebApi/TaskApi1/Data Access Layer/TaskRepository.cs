using System.Data.SqlClient;


namespace TaskApi.Models.Data
{
    public class TaskRepository
    {
        private readonly string connectionString;

        public TaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Task> GetAllTasks()
        {
            var tasks = new List<Task>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Task", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tasks.Add(new Task
                    {
                        TaskID = (int)reader["TaskID"],
                        TaskName = reader["TaskName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Duration = (int)reader["Duration"],
                        AssignedBy = reader["AssignedBy"].ToString()
                    });
                }
            }
            return tasks;
        }

        public Task GetTaskById(int taskId)
        {
            Task task = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Task WHERE TaskID = @TaskID", conn);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    task = new Task
                    {
                        TaskID = (int)reader["TaskID"],
                        TaskName = reader["TaskName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Duration = (int)reader["Duration"],
                        AssignedBy = reader["AssignedBy"].ToString()
                    };
                }
            }
            return task;
        }

        public void AddTask(Task task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Task (TaskName, Description, Duration, AssignedBy) VALUES (@TaskName, @Description, @Duration, @AssignedBy)", conn);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@Duration", task.Duration);
                cmd.Parameters.AddWithValue("@AssignedBy", task.AssignedBy);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTask(int taskId, Task task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Task SET TaskName = @TaskName, Description = @Description, Duration = @Duration, AssignedBy = @AssignedBy WHERE TaskID = @TaskID", conn);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@Duration", task.Duration);
                cmd.Parameters.AddWithValue("@AssignedBy", task.AssignedBy);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int taskId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Task WHERE TaskID = @TaskID", conn);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

