using TodoList.Domain.Entities.Users;

namespace TodoList.Services.Abstractions;

public interface IAuthService
{
    User VerifyEmailAndPassword(string email, string password);
}