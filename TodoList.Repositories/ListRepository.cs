using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Lists;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Contexts;

namespace TodoList.Repositories;

public class ListRepository : Repository<List, Guid>, IListRepository
{
    public ListRepository(TodoListContext context) 
        : base(context) { }
}
