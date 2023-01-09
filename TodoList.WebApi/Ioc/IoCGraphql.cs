using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoList.WebApi.Graph.User;

namespace TodoList.WebApi.Ioc;

public static class IoCGraphql
{
    public static void ConfigureGraphQlServices(this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.RegisterGraphQlStuffs();
    }
    
    private static void RegisterGraphQlStuffs(this IServiceCollection services)
    {
        services.TryAddScoped<ISchema, UserSchema>();
    }
}