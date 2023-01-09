using GraphQL.Types;

namespace TodoList.WebApi.Graph.User;

public class UserSchema : Schema
{
    public UserSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<UserQuery>();
        Mutation = serviceProvider.GetRequiredService<UserMutation>();
    }
}