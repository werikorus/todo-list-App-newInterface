using TodoList.Domain.Entities.Users;

namespace TodoList.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}