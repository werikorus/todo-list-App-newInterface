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

    [HttpGet("ListId={idList}/UserId={idUser}")]
    public IActionResult GetById(Guid idList, Guid idUser)
    {
        try
        {
            if (Guid.Empty == idUser && Guid.Empty == idList) 
                return BadRequest("Invalid Identifier!");
            
            var task = _taskListService.GetTasksByListIdAndUserId(idList, idUser);

            return (task is null)
                ? NotFound("Task not found!")
                : Ok(task);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var tasks = _taskListService.GetAll();

            return (tasks.Count == 0)
                ? NotFound()
                : Ok(tasks);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] TaskListModel model)
    {
        try
        {
            if (model.Id.HasValue && _taskListService.Exists(model.Id.Value))
                return Conflict();

            var task = _taskListService.Save(model);
            if (!task.Valid()) return BadRequest(task.Notification.GetErrors);

            return CreatedAtAction(nameof(GetById),
                new { Id = task.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, task);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] TaskListModel model)
    {
        try
        {
            if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
            if (model?.Id != id) return UnprocessableEntity("Identifier diverges from solicited object!");
            if (!_taskListService.Exists(id)) return NotFound();

            var task = _taskListService.Edit(model);
            if (!task.Valid()) return BadRequest(task.Notification.GetErrors);

            return Ok(task);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            if (!_taskListService.Exists(id)) return NotFound("Task not found!");

            _taskListService.Delete(id);

            return Accepted("Deletion sucessfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}