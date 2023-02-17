using TodoList.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Abstractions;
using TodoList.Services.Interfaces;
using TodoList.Services.Services;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class AuthController : TodoListControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IAuthService _authService;

/*    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _authService = authService;
    }*/
    
    
    [HttpPost]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        try
        {
            var user = _authService.VerifyEmailAndPassword(dto.Email, dto.Password);
            
            if (user == null)
                return NotFound("User not found for authenticate!");

            var token = _tokenService.GenerateToken(user);
            return Ok(token);
            
        }
        catch
        {
            return StatusCode(500);
        }
    }
}