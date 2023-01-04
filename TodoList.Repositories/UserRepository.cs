using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Contexts;

namespace TodoList.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(TodoListContext context)
        :base(context){}
}