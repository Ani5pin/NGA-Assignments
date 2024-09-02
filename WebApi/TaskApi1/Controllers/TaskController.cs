using Microsoft.AspNetCore.Mvc;
using TaskModel = TaskApi.Models.Task;
using TaskApi.Models.Data;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskRepository _taskRepository;

        public TaskController(IConfiguration configuration)
        {
            _taskRepository = new TaskRepository(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]

        public IActionResult Get()
        {
            var tasks = _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel task)
        {
            _taskRepository.AddTask(task);
            return CreatedAtAction(nameof(Get), new { id = task.TaskID }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel task)
        {
            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null) return NotFound();

            _taskRepository.UpdateTask(id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null) return NotFound();

            _taskRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
