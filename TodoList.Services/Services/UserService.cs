using AutoMapper;
using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.Services.Services;
public class UserService : Service<User, UserModel, Guid>, IUserService
{
    public UserService(IUserRepository userRepository, IMapper mapper)
        : base(userRepository, mapper) { }
}