using TodoList.Domain.Abstraction.Builders;

namespace TodoList.Domain.Entities.Lists;

public class ListBuilder : Builder<ListBuilder, List, Guid>, IListBuilder
{
    private string _descriptionList;

    private DateTime _dateCreate;

    private DateTime _dateUpdate;
    

    public IListBuilder WithDescriptionList(string descriptionList)
    {
        _descriptionList = descriptionList;
        return this;
    }

    public IListBuilder WithDateCreate(DateTime dateCreate)
    {
        _dateCreate = dateCreate;
        return this;
    }

    public IListBuilder WithDateUpdate(DateTime dateUpdate)
    {
        _dateUpdate = dateUpdate;
        return this;
    }

    public override List Build() => new List(Id, _descriptionList, _dateCreate, _dateUpdate);
}