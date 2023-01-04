using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Abstractions;

namespace TodoList.Repositories;

public interface IUserRepository : IRepository<User, Guid> {}
