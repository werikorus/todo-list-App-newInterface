using AutoMapper;
using TodoList.Domain.Entities.Lists;
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
            .WitIdUser(source.IdUser)
            .Build();

        return list;
    }
}