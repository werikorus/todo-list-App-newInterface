using TodoList.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Services;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class AuthController : TodoListControllerBase
{
    private readonly TokenService _userService;
    private readonly IUserRepository _authRepository;
    
    [HttpPost]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        try
        {
            var user = _authRepository.VerifyEmailAndPassword(dto.Email, dto.Password);

            if (user == null)
                return NotFound("User not found for authenticate!");

            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }
        catch
        {
            return StatusCode(500);
        }
    }
}