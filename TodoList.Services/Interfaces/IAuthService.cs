using TodoList.Domain.Entities.Users;

namespace TodoList.Services.Interfaces;

public interface IAuthService
{
    User VerifyEmailAndPassword(string email, string password);
}