using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Abstraction.Notifications;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v1;
[ApiVersion("1")]
 
public class ListController : TodoListControllerBase
{
    private readonly IListService _listService;

    public ListController(IListService listService)
    {
        _listService = listService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

        var list = _listService.GetById(id);
        
        return (list is null) 
            ? NotFound("List not found!") 
            : Ok(list);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var lists = _listService.GetAll();

        return (lists.Count == 0)
            ? NotFound()
            : Ok(lists);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ListModel model)
    {
        if (model.Id.HasValue && _listService.Exists(model.Id.Value)) 
            return Conflict();

        var list = _listService.Save(model);
        if (!list.Valid()) return BadRequest("Notification.GetErrors()");

        return CreatedAtAction(nameof(GetById),
            new { Id = list.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, list);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ListModel model)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");
        if (model?.Id != id) return UnprocessableEntity("Identifier diverges from solicited object!");
        if (!_listService.Exists(id)) return NotFound();

        var list = _listService.Edit(model);
        if (!list.Valid()) return BadRequest("Notification.GetErrors()");

        return Ok(list);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!_listService.Exists(id)) return NotFound("List not found!");
        
        _listService.Delete(id);

        return Accepted("Deletion sucessfully");
    }
}