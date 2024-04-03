using AutoMapper;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Models;

namespace TodoList.Services.Mappers.Converters;

public class UserModelDomainConverter : ITypeConverter<UserModel, User>
{
    public User Convert(UserModel source, User destination, ResolutionContext context)
        => source is null || context is null
            ? default
            : new UserBuilder()
                .WithId(source.Id ?? Guid.NewGuid())
                .WithName(source.Name)
                .WithPassword(source.Password)
                .WithEmail(source.Email)
                .WithRole(source.Role)
                .WithUrlAvatar(source.UrlAvatar)
                .WithDateCreate(source.DateCreate)
                .WithDateUpdate(source.DateUpdate)
                .Build();
}