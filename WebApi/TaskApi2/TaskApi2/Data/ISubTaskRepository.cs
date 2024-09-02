using TaskApi2.Models;

namespace TaskApi2.Data
{
    public interface ISubTaskRepository
    {
        SubTask GetSubTaskById(int id);
        IEnumerable<SubTask> GetAllSubTasks();
        void AddSubTask(SubTask subTask);
        void UpdateSubTask(SubTask subTask);
        void DeleteSubTask(int id);
    }
}