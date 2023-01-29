using TodoList.Domain.Abstraction;
using TodoList.Domain.Abstraction.Builders;

namespace TodoList.Domain.Entities.Users;

public class UserBuilder: Builder<UserBuilder, User, Guid>, IUserBuilder
{
    private string _name;
    
    private string _password;
    
    private string _email;
    
    private string _role;
    
    private DateTime _dateCreate;
    
    private DateTime _dateUpdate;
    
    
    public IUserBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IUserBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }

    public IUserBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public IUserBuilder WithRole(string role)
    {
        _role = role;
        return this;
    }

    public IUserBuilder WithDateCreate(DateTime dateCreate)
    {
        _dateCreate = dateCreate;
        return this;
    }

    public IUserBuilder WithDateUpdate(DateTime dateUpdate)
    {
        _dateUpdate = dateUpdate;
        return this;
    }

    public override User Build() => new User(Id, _name, _password, _email, _role, _dateCreate, _dateUpdate);
}