using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Abstraction.Notifications;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Models;
using TodoList.Services.Interfaces;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class UserController : TodoListControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

        var user = _userService.GetById(id);

        return (user is null)
            ? NoContent()
            : Ok(user);
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        var users = _userService.GetAll();

        return (users.Count == 0)
            ? NotFound()
            : Ok(users);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserModel model)
    {
        if (model.Id.HasValue && _userService.Exists(model.Id.Value))
            return Conflict();

        var user = _userService.Save(model);
        if (user.Valid() == false) return BadRequest("Notification.GetErrors()");

        return CreatedAtAction(nameof(GetById),
            new { Id = user.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] UserModel model)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier");
        if (model?.Id == id) return UnprocessableEntity("Identifier diverges from solicited object!");
        if (_userService.Exists(id) == false) return NotFound();

        var user = _userService.Edit(model);
        
        return (!user.Valid())
            ? BadRequest("Notification.GetErrors()")
            : Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (_userService.Exists(id) == false) return NotFound();

        _userService.Delete(id);
        return Accepted();
    }
}