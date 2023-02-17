using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Abstractions;

public interface IAuthRepository
{
    User VerifyUserAndPassword(string email, string password);
}