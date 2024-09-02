
using TaskModel = TaskApi2.Models.Task;
namespace TaskApi2.Data
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> GetTaskByIdAsync(int taskId);
        Task AddTaskAsync(TaskModel task);
        Task UpdateTaskAsync(TaskModel task);
        Task DeleteTaskAsync(int taskId);
    }
}