using AutoMapper;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Models;

namespace TodoList.Services.Mappers;

public class DomainToModelProfile : Profile
{
    public DomainToModelProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<List, ListModel>();
        CreateMap<TaskList, TaskListModel>();
    }
}