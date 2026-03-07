using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Services;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            var created = _service.Create(task.Title);
            return Ok(created);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult CompleteTask(int id)
        {
            var task = _service.Complete(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }
    }
}