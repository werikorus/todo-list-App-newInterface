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

    [HttpGet("listId={listId}")]
    public async Task<IActionResult> GetByIdAsync(Guid listId, CancellationToken cancellationToken)
    {
        try
        {
            if (Guid.Empty == listId) return BadRequest("Invalid Identifier!");

            var list = await _listService.GetByIdAsync(listId, cancellationToken);

            return (list is null)
                ? NotFound("List not found!")
                : Ok(list);
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

    [HttpPut("listId={listId}")]
    public async Task<IActionResult> PutAsync(Guid listId, [FromBody] ListModel model, CancellationToken cancellationToken)
    {
        try
        {
            if (Guid.Empty == listId) return BadRequest("Invalid Identifier!");
            if (model?.Id != listId) return UnprocessableEntity("Identifier diverges from solicited object!");
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

    [HttpDelete("listId={listId}")]
    public async Task<IActionResult> Delete(Guid listId, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _listService.ExistsAsync(listId, cancellationToken)) return NotFound("List not found!");

            await _listService.DeleteAsync(listId, cancellationToken);

            return Accepted("Deletion sucessfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}