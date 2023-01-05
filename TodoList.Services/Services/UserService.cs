using TodoList.Domain.Entities.Users;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.Services.Services;

public class UserService : IUserService
{
    private IUserService _userServiceImplementation;
    public void Delete(Guid id)
    {
        _userServiceImplementation.Delete(id);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _userServiceImplementation.DeleteAsync(id, cancellationToken);
    }

    public User Edit(UserModel model)
    {
        return _userServiceImplementation.Edit(model);
    }

    public Task<User> EditAsync(UserModel model, CancellationToken cancellationToken)
    {
        return _userServiceImplementation.EditAsync(model, cancellationToken);
    }

    public bool Exists(Guid id)
    {
        return _userServiceImplementation.Exists(id);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken calCancellationToken)
    {
        return _userServiceImplementation.ExistsAsync(id, calCancellationToken);
    }

    public IList<User> GetAll()
    {
        return _userServiceImplementation.GetAll();
    }

    public Task<IList<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _userServiceImplementation.GetAllAsync(cancellationToken);
    }

    public User GetById(Guid id)
    {
        return _userServiceImplementation.GetById(id);
    }

    public Task<User> GetByIdAsync(Guid id, CancellationToken calCancellationToken)
    {
        return _userServiceImplementation.GetByIdAsync(id, calCancellationToken);
    }

    public User Save(UserModel model)
    {
        return _userServiceImplementation.Save(model);
    }

    public Task<User> SaveAsync(UserModel model, CancellationToken cancellationToken)
    {
        return _userServiceImplementation.SaveAsync(model, cancellationToken);
    }
}