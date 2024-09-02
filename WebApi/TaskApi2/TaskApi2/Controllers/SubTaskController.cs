using Microsoft.AspNetCore.Mvc;
using TaskApi2.Models;

namespace TaskApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly Data.ISubTaskRepository _subTaskRepository;

        public SubTaskController(Data.ISubTaskRepository subTaskRepository)
        {
            _subTaskRepository = subTaskRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var subTasks = _subTaskRepository.GetAllSubTasks();
            return Ok(subTasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var subTask = _subTaskRepository.GetSubTaskById(id);
            if (subTask == null) return NotFound();
            return Ok(subTask);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubTask subTask)
        {
            _subTaskRepository.AddSubTask(subTask);
            return CreatedAtAction(nameof(Get), new { id = subTask.SubTaskId }, subTask);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SubTask subTask)
        {
            if (id != subTask.SubTaskId) return BadRequest();
            _subTaskRepository.UpdateSubTask(subTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subTaskRepository.DeleteSubTask(id);
            return NoContent();
        }
    }
}