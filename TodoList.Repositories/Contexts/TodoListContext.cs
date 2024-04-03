using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Contexts;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions options)
        : base(options) { }

    public DbSet<User> User { get; set; }

    public DbSet<List> List { get; set; }

    public DbSet<TaskList> TaskList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListContext).Assembly);
        //modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }
}
