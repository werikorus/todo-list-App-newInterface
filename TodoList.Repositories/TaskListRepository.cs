using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.TasksList;
using TodoList.Repositories.Abstractions;
using TodoList.Repositories.Contexts;
using TodoList.Repositories.Interfaces;

namespace TodoList.Repositories;

public class TaskListRepository : Repository<TaskList, Guid>, ITaskListRepository
{
    public TaskListRepository(TodoListContext context) 
        : base(context) { }
}