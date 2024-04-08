using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class UserController : TodoListControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("userId={userId}")]
    public IActionResult GetByUserId(Guid userId)
    {
        try
        {
            if (Guid.Empty == userId) return BadRequest("Invalid Identifier!");

            var user = _userService.GetById(userId);

            return (user is null)
                ? NoContent()
                : Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet] 
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        try
        {
            var users = _userService.GetAll();

            return (users.Count == 0)
                ? NotFound()
                : Ok(users);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public IActionResult InsertNewUser([FromBody] UserModel model)
    {
        try
        {
            if (model.Id.HasValue && _userService.Exists(model.Id.Value))
                return Conflict();

            var user = _userService.Save(model);
            if (user.Valid() == false)
                return BadRequest(user.Notification.GetErrors);

            return CreatedAtAction(nameof(GetByUserId),
                new { Id = user.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut("userId={userId}")]
    public IActionResult UpdateUser(Guid userId, [FromBody] UserModel model)
    {
        try
        {
            if (Guid.Empty == userId) return BadRequest("Invalid Identifier");
            if (model?.Id == userId) return UnprocessableEntity("Identifier diverges from solicited object!");

            if (_userService.Exists(userId) == false) return NotFound();

            var user = _userService.Edit(model);

            return (!user.Valid())
                ? BadRequest(user.Notification.GetErrors)
                : Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("userId={userId}")]
    public IActionResult DeleteUser(Guid userId)
    {
        try
        {
            if (_userService.Exists(userId) == false) return NotFound();

            _userService.Delete(userId);
            return Accepted("Deletion sucessfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}