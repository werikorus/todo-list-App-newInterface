using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Abstractions;

namespace TodoList.Repositories.Interfaces;

public interface IUserRepository : IRepository<User, Guid> { }
