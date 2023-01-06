using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.TasksList;
using TodoList.Services.Abstractions;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v2;
[ApiVersion("2")]

public class TaskListController : TodoListControllerBase
{
    private readonly ITasksListService _taskListService;

    public TaskListController(ITasksListService taskListService)
    {
        _taskListService = taskListService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

        var task = await  _taskListService.GetByIdAsync(id, cancellationToken);
        
        return (task is null) 
            ? NotFound("List not found!") 
            : Ok(task);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskListService.GetAllAsync(cancellationToken);

        return (tasks.Count == 0)
            ? NotFound()
            : Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TaskListModel model, CancellationToken cancellationToken)
    {
        if (model.Id.HasValue && await _taskListService.ExistsAsync(model.Id.Value, cancellationToken)) 
            return Conflict();

        var task = _taskListService.Save(model);
        if (!task.Valid()) return BadRequest("Notification.GetErrors()");

        var listResult = await _taskListService.GetByIdAsync(model.Id.Value, cancellationToken);

        return Ok(listResult);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] TaskListModel model, CancellationToken cancellationToken)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
        if (model?.Id != id) return UnprocessableEntity("Identifier diverges from solicited object!");
        if (! await _taskListService.ExistsAsync(model.Id.Value, cancellationToken)) return NotFound();

        var task = await _taskListService.EditAsync(model, cancellationToken);
        if (!task.Valid()) return BadRequest("Notification.GetErrors()");

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        if (! await _taskListService.ExistsAsync(id, cancellationToken)) return NotFound("Task not found!");
        
        await _taskListService.DeleteAsync(id, cancellationToken);

        return Accepted("Deletion sucessfully");
    }
}