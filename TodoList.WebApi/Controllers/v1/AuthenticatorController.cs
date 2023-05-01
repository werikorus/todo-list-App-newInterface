using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Dto;
using TodoList.Services.Interfaces;
using TodoList.Services.Services;

namespace TodoList.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class AuthenticatorController : TodoListControllerBase
    {
        private readonly IUserService _userService;
        
        public AuthenticatorController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            try
            {
                var user = _userService.LoginUser(dto.Email, dto.Password);

                if (user == null)
                    return NotFound("User not found to authenticate!");

                var token = TokenService.GenerateToken(user);
               
                return Ok(token);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}