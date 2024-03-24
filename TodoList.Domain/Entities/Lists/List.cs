using TodoList.Domain.Abstraction;


namespace TodoList.Domain.Entities.Lists;

public class List : Entity<Guid>
{
    internal List(Guid id, Guid idUser, string descriptionList, DateTime dateCreate, DateTime dateUpdate)
    {
        SetId(id);
        SetUserId(idUser);
        SetDescriptionList(descriptionList);
        SetDateCreate(dateCreate);
        SetDateUpdate(dateUpdate);
    }


    protected List()
    {
    }

    public string DescriptionList { get; set; }

    public Guid IdUser { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }

    protected sealed override void SetId(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_Identifier_invalid);
            return;
        }

        Id = id;
    }

    private void SetUserId(Guid idUser)
    {
        if (idUser.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_Identifier_invalid);
            return;
        }

        IdUser = idUser;
    }

    private void SetDescriptionList(string descriptionList)
    {
        if (descriptionList.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_descriptionList_invalid);
            return;
        }

        DescriptionList = descriptionList;
    }

    private void SetDateCreate(DateTime dateCreate)
    {
        if (dateCreate.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_dateCreate_invalid);
            return;
        }

        DateCreate = dateCreate;
    }

    private void SetDateUpdate(DateTime dateUpdate)
    {
        if (dateUpdate.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_dateUpdate_invalid);
            return;
        }

        DateUpdate = dateUpdate;
    }
}