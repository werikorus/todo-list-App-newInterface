using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.WebApi.Controllers.v2;

[ApiVersion("2")]
public class UserController : TodoListControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("userId={userId}")]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            if (Guid.Empty == userId) return BadRequest("Invalid Identifier!");

            var user = await _userService.GetByIdAsync(userId, cancellationToken);

            if (user is null) return NotFound("User not found!");
            if (!user.Valid()) return BadRequest("Notification.GetErrors()");

            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userService.GetAllAsync(cancellationToken);
            if (users.Count == 0) return NotFound();

            return Ok(users);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertNewUserAsync([FromBody] UserModel model, CancellationToken cancellationToken)
    {
        try
        {
            if (model.Id.HasValue && await _userService.ExistsAsync(model.Id.Value, cancellationToken))
                return Conflict();

            var user = await _userService.SaveAsync(model, cancellationToken);
            if (user.Valid() == false) return BadRequest("Notification.GetErrors()");

            var userResult = await GetByUserIdAsync(user.Id, cancellationToken);

            return Ok(userResult);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut("userId={userId}")]
    public async Task<IActionResult> UpdateUserAsync(Guid userId, [FromBody] UserModel model, CancellationToken cancellationToken)
    {
        try
        {
            if (Guid.Empty == userId) return BadRequest("Invalid Identifier");
            if (model?.Id == userId) return UnprocessableEntity("Identifier diverges from solicited object!");
            if (await _userService.ExistsAsync(userId, cancellationToken) == false) return NotFound();

            var user = await _userService.EditAsync(model, cancellationToken);
            if (!user.Valid()) return BadRequest("Notification.GetErrors()");

            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("userId={id}")]
    public async Task<IActionResult> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _userService.ExistsAsync(userId, cancellationToken)) return NotFound();

            await _userService.DeleteAsync(userId, cancellationToken);
            return Accepted("Deletion Sucessfully!");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}