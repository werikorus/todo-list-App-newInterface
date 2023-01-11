using AutoMapper;
using TodoList.Domain.Entities.TasksList;
using TodoList.Services.Models;

namespace TodoList.Services.Mappers.Converters;

public class TaskListModelDomainConverter : ITypeConverter<TaskListModel, TaskList>
{
    public TaskList Convert(TaskListModel source, TaskList destination, ResolutionContext context)
        => source is null || context is null
            ? default
            : new TaskListBuilder()
                .WithId(source.Id ?? Guid.NewGuid())
                .WithIdList(source.IdList)
                .WithDescriptionTask(source.DescriptionTask)
                .WithDateCreate(source.DateCreate)
                .WithDateUpdate(source.DateUpdate)
                .WithIdUser(source.IdUser)
                .WithDone(source.Done)
                .Build();
}
    
