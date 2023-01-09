using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.Services.Interfaces;
using TodoList.Services.Mappers;
using TodoList.Services.Services;
using TodoList.Services.Validators;
using GraphQL.MicrosoftDI;
using GraphQL.Types;

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

    public static void ConfigureServices(this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.RegisterGraphQlServices();
    }

    private static void RegisterGraphQlServices(this IServiceCollection services)
    {
        services.AddSingleton<ISchema, UserSchema>(services => new UserSchema(new SelfActivatingServiceProvider(services)));
    }

    public static IMvcCoreBuilder AddFluentValidation(this IMvcCoreBuilder builder)
        => builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserModelValidator>());
}