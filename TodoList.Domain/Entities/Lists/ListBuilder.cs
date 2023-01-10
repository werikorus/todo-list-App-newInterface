using TodoList.Domain.Abstraction.Builders;

namespace TodoList.Domain.Entities.Lists;

public class ListBuilder : Builder<ListBuilder, List, Guid>, IListBuilder
{
    private string _descriptionList;

    private DateTime _dateCreate;

    private DateTime _dateUpdate;

    private Guid _idUser;
    
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

    public IListBuilder WitIdUser(Guid idUser)
    {
        _idUser = idUser;
        return this;
    }
    
    public override List Build() => new List(Id, _idUser, _descriptionList, _dateCreate, _dateUpdate);
}