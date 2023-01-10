using TodoList.Domain.Abstraction.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Entities.Lists;

public interface IListBuilder : IBuilder<List, Guid>
{
    IListBuilder WithDescriptionList(string descriptionList);
    IListBuilder WitIdUser(Guid idUser);
    IListBuilder WithDateCreate(DateTime dateCreate);
    IListBuilder WithDateUpdate(DateTime dateUpdate);
}