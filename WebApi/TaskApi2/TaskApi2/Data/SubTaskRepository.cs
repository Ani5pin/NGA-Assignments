using Microsoft.EntityFrameworkCore;
using TaskApi2.Models;

namespace TaskApi2.Data
{
    public class SubTaskRepository : ISubTaskRepository
    {
        private readonly TaskDbContext _context;

        public SubTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public SubTask GetSubTaskById(int id) => _context.SubTasks
            .Include(st => st.Task)
            .FirstOrDefault(st => st.SubTaskId == id);

        public IEnumerable<SubTask> GetAllSubTasks() => _context.SubTasks
            .Include(st => st.Task)
            .ToList();

        public void AddSubTask(SubTask subTask)
        {
            _context.SubTasks.Add(subTask);
            _context.SaveChanges();
        }

        public void UpdateSubTask(SubTask subTask)
        {
            _context.SubTasks.Update(subTask);
            _context.SaveChanges();
        }

        public void DeleteSubTask(int id)
        {
            var subTask = _context.SubTasks.Find(id);
            if (subTask != null)
            {
                _context.SubTasks.Remove(subTask);
                _context.SaveChanges();
            }
        }
    }
}