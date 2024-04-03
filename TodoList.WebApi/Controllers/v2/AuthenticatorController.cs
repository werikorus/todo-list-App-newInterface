using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Dto;
using TodoList.Services.Interfaces;
using TodoList.Services.Services;

namespace TodoList.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    public class AuthenticatorController : TodoListControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticatorController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.LoginUserAsync(dto.Email, dto.Password, cancellationToken);

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
