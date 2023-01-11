using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Interfaces;

public interface ITodoListContext : IDbContext
{
    DbSet<User> Users { get; set;}
    
    DbSet<List> Lists { get; set;}

    DbSet<TaskList> TaskList { get; set; }
}