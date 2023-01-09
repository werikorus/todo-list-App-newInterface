using AutoMapper;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Services.Models;

namespace TodoList.Services.Mappers.Converters;

public class ListModelDomainConverter : ITypeConverter<ListModel, List>
{
    public List Convert(ListModel source, List destination, ResolutionContext context)
    {
        var list = new ListBuilder()
            .WithId(source.Id ?? Guid.NewGuid())
            .WithDescriptionList(source.DescriptionList)
            .WithDateCreate(source.DateCreate)
            .WithDateUpdate(source.DateUpdate)
            .Build();

        foreach (var sourceList in source.TasksList ?? new List<TaskListModel>())
            list.AddTasksList(context.Mapper.Map<TaskListModel, TaskList>(sourceList));

        return list;
    }
}