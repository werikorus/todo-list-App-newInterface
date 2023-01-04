using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.Users;
using TodoList.Services;
using TodoList.Services.Models;
using TodoList.Domain.Abstraction.Notifications;

namespace TodoList.WebApi.Controllers.v2;

public class UserController : TodoListControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        if (!await _userService.ExistsAsync(id, cancellationToken) == false) return NotFound();
        
        await _userService.DeleteAsync(id, cancellationToken);
        return Accepted("Deletion Sucessfully!");
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        if (users.Count == 0) return NotFound();

        return Ok(users);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

        var user = await _userService.GetByIdAsync(id, cancellationToken);
        
        if (user is null) return NotFound("User not found!");

        if (user.Valid() == false) return BadRequest("Notification.GetErrors()");

        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserModel model, CancellationToken cancellationToken)
    {
        if (model.Id.HasValue && await  _userService.ExistsAsync(model.Id.Value, cancellationToken))
            return Conflict();

        var user = await _userService.SaveAsync(model, cancellationToken);
        if (user.Valid() == false) return BadRequest("Notification.GetErrors()");

        /*return CreatedAtAction(nameof(GetByIdAsync),
            new { id = user.Id, cancellationToken, version = HttpContext.GetRequestedApiVersion()?.ToString()}, user);*/
        
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] UserModel model, CancellationToken cancellationToken)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier");
        if (model?.Id == id) return UnprocessableEntity("Identifier diverges from solicited object!");
        if (await _userService.ExistsAsync(id, cancellationToken) == false) return NotFound();

        var user = await _userService.EditAsync(model, cancellationToken);
        if (user.Valid() == false) return BadRequest("Notification.GetErrors()");

        return Ok(user);
    }
}