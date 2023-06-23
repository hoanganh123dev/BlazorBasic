using BlazorAPI.Data;
using BlazorAPI.Entities;
using BlazorAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Task = BlazorAPI.Entities.Task;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        //api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks =  await _taskRepository.GetTaskList();
            return Ok(tasks);
        }
        //api/tasks/id
        [HttpGet]
        [Route("{:id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tasks = await _taskRepository.GetById(id);
            if(tasks == null)   return NotFound($"{id} is not found");
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Task task)
        {
            if(ModelState.IsValid)
                return BadRequest(ModelState);

            var tasks = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetById),new { id = task.Id}, tasks);
        }
        [HttpPut]
        [Route("{:id}")]
        public async Task<IActionResult> Update(Guid id, Task task)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = await _taskRepository.GetById(id);
            if (taskFromDb == null)
            {
                return NotFound($"{id} is not found");
            }

            taskFromDb.Name = task.Name;
            var tasks = await _taskRepository.Update(id,task);
            return Ok(tasks);
        }
    }
}
