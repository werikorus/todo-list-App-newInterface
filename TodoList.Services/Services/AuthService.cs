using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Abstractions;

namespace TodoList.Services.Services;

public class AuthService : IAuthService
{
    private IAuthorizationRepository _authRepository;
    
    protected AuthService(IAuthorizationRepository repository)
    {
        _authRepository = repository;
    }

    public User VerifyEmailAndPassword(string email, string password)
    {
        return _authRepository.VerifyEmailAndPassword(email, password);
    }
}