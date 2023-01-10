using GraphQL.Types;

namespace TodoList.WebApi.Graph.User.Types;
public class UserType : ObjectGraphType<Domain.Entities.Users.User>
{
    public UserType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Password);
        Field(x => x.Email);
        Field(x => x.DateCreate);
        Field(x => x.DateUpdate);
    }
}