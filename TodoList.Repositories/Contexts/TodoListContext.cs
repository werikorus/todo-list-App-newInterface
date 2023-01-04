using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Users;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;

namespace TodoList.Repositories.Contexts;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions options)
        :base(options){}
    
    public DbSet<User> Users { get; set;}
    
    public DbSet<List> Lists { get; set;}

    public DbSet<TaskList> TaskList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListContext).Assembly);
        //modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }
}