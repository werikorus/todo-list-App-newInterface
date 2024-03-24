using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v2;

[ApiVersion("2")]
public class ListController : TodoListControllerBase
{
    private readonly IListService _listService;

    public ListController(IListService listService)
    {
        _listService = listService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

            var list = await _listService.GetByIdAsync(id, cancellationToken);

            return (list is null)
                ? NotFound("List not found!")
                : Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var lists = await _listService.GetAllAsync(cancellationToken);

            return (lists.Count == 0)
                ? NotFound("Users not found!")
                : Ok(lists);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ListModel model, CancellationToken cancellationToken)
    {
        try
        {
            if (model.Id.HasValue && await _listService.ExistsAsync(model.Id.Value, cancellationToken))
                return Conflict();

            var list = _listService.Save(model);
            if (!list.Valid()) return BadRequest("Notification.GetErrors()");

            var listResult = await _listService.GetByIdAsync(model.Id.Value, cancellationToken);

            return Ok(listResult);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] ListModel model, CancellationToken cancellationToken)
    {
        try
        {
            if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
            if (model?.Id != id) return UnprocessableEntity("Identifier diverges from solicited object!");
            if (!await _listService.ExistsAsync(model.Id.Value, cancellationToken)) return NotFound();

            var list = await _listService.EditAsync(model, cancellationToken);
            if (!list.Valid()) return BadRequest("Notification.GetErrors()");

            return Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _listService.ExistsAsync(id, cancellationToken)) return NotFound("List not found!");

            await _listService.DeleteAsync(id, cancellationToken);

            return Accepted("Deletion sucessfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}