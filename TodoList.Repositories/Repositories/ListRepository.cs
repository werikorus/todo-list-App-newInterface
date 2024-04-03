using TodoList.Domain.Entities.Lists;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Contexts;
using TodoList.Repositories.Interfaces;

namespace TodoList.Repositories;

public class ListRepository : Repository<List, Guid>, IListRepository
{
    public ListRepository(TodoListContext context)
        : base(context) { }
}
