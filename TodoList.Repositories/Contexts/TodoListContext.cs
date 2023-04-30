using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Users;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;

namespace TodoList.Repositories.Contexts;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions options)
        :base(options){}
    
    public DbSet<User> User { get; set;}
    
<<<<<<< HEAD
    public DbSet<List> List  { get; set;}
=======
    public DbSet<List> List { get; set;}
>>>>>>> 95892949e124d403b37721028fe8b3776398f758

    public DbSet<TaskList> TaskList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListContext).Assembly);
        //modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }
}