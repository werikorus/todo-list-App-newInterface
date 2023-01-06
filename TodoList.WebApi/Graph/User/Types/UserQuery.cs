using System;
using GraphQL;
using GraphQL.Types;
using TodoList.Services.Interfaces;

namespace TodoList.WebApi.Graph.User.Types;

public class UserQuery : ObjectGraphType
{
    public UserQuery()
    {
        Field<ListGraphType<UserType>>(
            "Users",
            resolve: Context =>
            {
                var service = Context.RequestServices.GetRequiredService<IUserService>();
                return service.GetAllAsync(CancellationToken.None);
            });

        Field<UserType>(
            "User",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>>
            {
                Name = "IdUser",
                Description = "Unique ID to localizate a User"
            }),
            resolve: Context =>
            {
                var id = Context.GetArgument<Guid>("Id");
                var service = Context.RequestServices.GetRequiredService<IUserService>();
                return service.GetByIdAsync(id, CancellationToken.None);
            });
    }
}