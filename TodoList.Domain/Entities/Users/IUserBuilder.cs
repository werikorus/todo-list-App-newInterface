using TodoList.Domain.Abstraction.Builders;

namespace TodoList.Domain.Entities.Users;

public interface IUserBuilder : IBuilder<User, Guid>
{
    IUserBuilder WithName(string name);
    IUserBuilder WithPassword(string password);
    IUserBuilder WithEmail(string email);
    IUserBuilder WithDateCreate(DateTime dateCreate);
    IUserBuilder WithDateUpdate(DateTime dateUpdate);
}