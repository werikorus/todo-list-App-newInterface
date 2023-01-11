using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Services.Interfaces;
using TodoList.Services.Mappers;
using TodoList.Services.Services;
using TodoList.Services.Validators;

namespace TodoList.Services.Ioc; 
public static class IoCServices
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        => services.AddAutoMapper(typeof(ModelToDomainProfile), typeof(DomainToModelProfile));
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IListService, ListsService>();
        services.AddScoped<ITasksListService, TasksListService>();
    }

    public static void AddFluentValidation(this IMvcCoreBuilder builder)
    {
        builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserModelValidator>());
        builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ListModelValidator>());
        builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TaskListModelValidator>());
    }
}