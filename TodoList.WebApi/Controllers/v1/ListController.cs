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

    [HttpGet("UserId/{id}")]
    public IActionResult GetListsByUserId(Guid id)
    {
        try
        {
            if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

            var list = _listService.GetListsByUserId(id);

            return (list is null)
                ? NotFound("List not found!")
                : Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

            var list = _listService.GetById(id);

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
    public IActionResult GetAll()
    {
        try
        {
            var lists = _listService.GetAll();

            return (lists.Count == 0)
                ? NotFound("There's not any list on the database. Create the first one!")
                : Ok(lists);
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

            return CreatedAtAction(nameof(GetById),
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

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ListModel model)
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

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            if (!_listService.Exists(id)) return NotFound("List not found!");
            _listService.Delete(id);
            return Accepted("Deletion sucessfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("UserId={userId}")]
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