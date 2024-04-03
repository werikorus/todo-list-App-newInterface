using GraphQL;
using GraphQL.Types;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;
using TodoList.WebApi.Graph.User.Types;

namespace TodoList.WebApi.Graph.User;
public class UserMutation : ObjectGraphType
{
    public UserMutation()
    {
        Field<UserType>(
        "CreateUser",
        arguments: new QueryArguments(
            new QueryArgument<NonNullGraphType<UserType>>
            {
                Name = "UserInput",
                Description = "User Object to create new register."
            }),

        resolve: Context =>
            {
                var user = Context.GetArgument<UserModel>("UserImput");
                var service = Context.RequestServices.GetRequiredService<IUserService>();
                return service.SaveAsync(user, CancellationToken.None);
            }
        );
    }
}