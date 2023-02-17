using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Interfaces;

public interface IAuthorizationRepository
{
    User VerifyEmailAndPassword(string email, string password);
}