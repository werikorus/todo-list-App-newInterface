using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.TasksList;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v1;
[ApiVersion("1")]

public class TaskListController : TodoListControllerBase
{
    private readonly ITasksListService _taskListService;

    public TaskListController(ITasksListService taskListService)
    {
        _taskListService = taskListService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
        var task = _taskListService.GetById(id);
        
        return (task is null) 
            ? NotFound("Task not found!") 
            : Ok(task);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = _taskListService.GetAll();

        return (tasks.Count == 0)
            ? NotFound()
            : Ok(tasks);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TaskListModel model)
    {
        if (model.Id.HasValue && _taskListService.Exists(model.Id.Value)) 
            return Conflict();

        var task = _taskListService.Save(model);
        if (!task.Valid()) return BadRequest(task.Notification.GetErrors);

        return CreatedAtAction(nameof(GetById),
            new { Id = task.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] TaskListModel model)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
        if (model?.Id != id) return UnprocessableEntity("Identifier diverges from solicited object!");
        if (!_taskListService.Exists(id)) return NotFound();

        var task = _taskListService.Edit(model);
        if (!task.Valid()) return BadRequest(task.Notification.GetErrors);

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_taskListService.Exists(id)) return NotFound("Task not found!");
        
        _taskListService.Delete(id);

        return Accepted("Deletion sucessfully");
    }
}