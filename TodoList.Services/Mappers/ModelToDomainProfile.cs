using AutoMapper;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Mappers.Converters;
using TodoList.Services.Models;

namespace TodoList.Services.Mappers;

public class ModelToDomainProfile : Profile
{
    public ModelToDomainProfile()
    {
        CreateMap<UserModel, User>()
            .ConvertUsing<UserModelDomainConverter>();

        CreateMap<ListModel, List>()
            .ConvertUsing<ListModelDomainConverter>();
        
        CreateMap<TaskListModel, TaskList>()
            .ConvertUsing<TaskListModelDomainConverter>();
    }
}