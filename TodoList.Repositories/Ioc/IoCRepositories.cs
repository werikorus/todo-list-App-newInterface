using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Repositories.Contexts;
using TodoList.Repositories.Interfaces;
using TodoList.Repositories.Repositories;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace TodoList.Repositories.Ioc;

public static class IoCRepositories
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<TodoListContext>(dbcontextoptions
            => dbcontextoptions.UseLazyLoadingProxies()
                .UseSqlite(configuration.GetConnectionString("DefaultConnection"), sqliteOptions
                    => sqliteOptions.MigrationsAssembly(typeof(TodoListContext).Assembly.GetName().Name)));

    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IListRepository, ListRepository>();
        services.AddScoped<ITaskListRepository, TaskListRepository>();
    }
}