using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Contexts;
using TodoList.Repositories.Interfaces;

namespace TodoList.Repositories.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(TodoListContext context)
        : base(context) {}
}