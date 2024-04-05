using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class ListController : TodoListControllerBase
{
    private readonly IListService _listService;
    private readonly IUserService _userService;

    public ListController(IListService listService, IUserService userService)
    {
        _listService = listService;
        _userService = userService;
    }

    [HttpGet("userId={userId}")]
    public IActionResult GetListsByUserId(Guid userId)
    {
        try
        {
            if (Guid.Empty == userId) return BadRequest("Invalid Identifier!");

            var list = _listService.GetListsByUserId(userId);

            return (list is null)
                ? NotFound("List not found!")
                : Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("listId={listId}")]
    public IActionResult GetListByListId(Guid listId)
    {
        try
        {
            if (Guid.Empty == listId) return BadRequest("Invalid Identifier!");

            var list = _listService.GetById(listId);

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
    public IActionResult Post([FromBody] ListModel model)
    {
        try
        {
            if (model.Id.HasValue && _listService.Exists(model.Id.Value))
                return Conflict();

            var list = _listService.Save(model);
            if (!list.Valid()) return BadRequest(list.Notification.GetErrors);

            return CreatedAtAction(nameof(GetListByListId),
                new
                {
                    Id = list.Id,
                    version = HttpContext.GetRequestedApiVersion()?.ToString()
                }, list);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut("listId={listId}")]
    public IActionResult UpdateList(Guid id, [FromBody] ListModel model)
    {
        try
        {
            if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
            if (model?.Id != id) return UnprocessableEntity("Identifier diverges from solicited object!");
            if (!_listService.Exists(id)) return NotFound();

            var list = _listService.Edit(model);
            if (!list.Valid()) return BadRequest(list.Notification.GetErrors);

            return Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("listId={listId}")]
    public IActionResult DeleteList(Guid listId)
    {
        try
        {
            if (!_listService.Exists(listId)) return NotFound("List not found!");
            _listService.Delete(listId);
            return Accepted("Deletion sucessfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("userId={userId}")]
    public IActionResult DeleteAllListsByUserId(Guid userId)
    {
        try
        {
            if (!_userService.Exists(userId)) return NotFound("User not found for delete list!");
            _listService.DeleteAllListsByUserId(userId);
            return Accepted();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}