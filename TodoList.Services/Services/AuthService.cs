using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Abstractions;
using TodoList.Services.Interfaces;

namespace TodoList.Services.Services;

public abstract class AuthService : IAuthService
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