using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Services.Mappers;
using TodoList.Services.Validators;

namespace TodoList.Services.Ioc;

public static class IoCServices
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        => services.AddAutoMapper(typeof(ModelToDomainProfile), typeof(DomainToModelProfile));

    public static IServiceCollection AddService(this IServiceCollection services)
        => services.AddScoped<IUserService, UserService>();

    public static IMvcCoreBuilder AddFluentValidation(this IMvcCoreBuilder builder)
        => builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserModelValidator>());

}