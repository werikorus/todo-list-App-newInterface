using TodoList.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using TodoList.Repositories.Repositories;
using TodoList.Services.Interfaces;
using TodoList.Services.Services;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]

public class AuthenticatorController : TodoListControllerBase
{
    private readonly IUserService _userService;
    
    public IActionResult Login([FromBody] LoginDto dto)
    {
        try
        {
            var user = _userService.VerifyUserAndPassword(dto.UserName, dto.Password);

            if (user == null)
                return NotFound();

            var token = TokenServices.GenerateToken(user);
            return Ok(token);
        }
        catch
        {
            return StatusCode(500);
        } 
    }
}
