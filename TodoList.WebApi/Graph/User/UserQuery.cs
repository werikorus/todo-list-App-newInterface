using GraphQL;
using GraphQL.Types;
using TodoList.Services.Interfaces;
using TodoList.WebApi.Graph.User.Types;

namespace TodoList.WebApi.Graph.User;

public abstract class UserQuery : ObjectGraphType
{
    public UserQuery()
    {
        Field<ListGraphType<UserType>>(
            "Users",
            resolve: context =>
            {
                var service = context.RequestServices.GetRequiredService<IUserService>();
                return service.GetAllAsync(CancellationToken.None);
            });

        Field<UserType>(
            "User",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>>
            {
                Name = "IdUser",
                Description = "Unique ID to localizate a User"
            }),
            resolve: context =>
            {
                var id = context.GetArgument<Guid>("Id");
                var service = context.RequestServices.GetRequiredService<IUserService>();
                return service.GetByIdAsync(id, CancellationToken.None);
            });
    }
}