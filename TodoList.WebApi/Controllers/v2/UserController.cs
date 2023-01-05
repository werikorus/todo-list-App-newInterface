using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Models;
using TodoList.Services.Interfaces;

namespace TodoList.WebApi.Controllers.v2;
[ApiVersion("2")]

public class UserController : TodoListControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier!");

        var user = await _userService.GetByIdAsync(id, cancellationToken);
        
        if (user is null) return NotFound("User not found!");

        if (!user.Valid()) return BadRequest("Notification.GetErrors()");

        return Ok(user);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        if (users.Count == 0) return NotFound();

        return Ok(users);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserModel model, CancellationToken cancellationToken)
    {
        if (model.Id.HasValue && await  _userService.ExistsAsync(model.Id.Value, cancellationToken))
            return Conflict();

        var user = await _userService.SaveAsync(model, cancellationToken);
        if (user.Valid() == false) return BadRequest("Notification.GetErrors()");

        var userResult = await GetByIdAsync(user.Id, cancellationToken);

        return Ok(userResult);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, [FromBody] UserModel model, CancellationToken cancellationToken)
    {
        if (Guid.Empty == id) return BadRequest("Invalid Identifier");
        if (model?.Id == id) return UnprocessableEntity("Identifier diverges from solicited object!");
        if (await _userService.ExistsAsync(id, cancellationToken) == false) return NotFound();

        var user = await _userService.EditAsync(model, cancellationToken);
        if (!user.Valid()) return BadRequest("Notification.GetErrors()");

        return Ok(user);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        if (!await _userService.ExistsAsync(id, cancellationToken)) return NotFound();
        
        await _userService.DeleteAsync(id, cancellationToken);
        return Accepted("Deletion Sucessfully!");
    }
}