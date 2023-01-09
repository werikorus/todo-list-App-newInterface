using GraphQL;
using GraphQL.Types;
using TodoList.Services.Interfaces;
using TodoList.WebApi.Graph.User.Types;

namespace TodoList.WebApi.Graph.User;

public class UserQuery : ObjectGraphType
{
    public UserQuery()
    {
        Field<ListGraphType<UserType>>(
            "Users",
            resolve: context =>
            {
                if (context.RequestServices != null)
                {
                    var service = context.RequestServices.GetRequiredService<IUserService>();
                    return service.GetAllAsync(CancellationToken.None);
                }

                return null;
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
                if (context.RequestServices != null)
                {
                    var service = context.RequestServices.GetRequiredService<IUserService>();
                    return service.GetByIdAsync(id, CancellationToken.None);
                }

                return null;
            });
    }
}