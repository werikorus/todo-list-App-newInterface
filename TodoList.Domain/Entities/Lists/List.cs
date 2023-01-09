using TodoList.Domain.Abstraction;
using TodoList.Domain.Entities.TasksList;


namespace TodoList.Domain.Entities.Lists;

public class List : Entity<Guid>
{
    internal List(Guid id, string descriptionList, DateTime dateCreate, DateTime dateUpdate)
    {
        SetId(id);
        SetDescriptionList(descriptionList);
        SetDateCreate(dateCreate);
        SetDateUpdate(dateUpdate);
        TasksList = new List<TaskList>();
    }

    protected List()
    {
    }

    public string DescriptionList { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
    public virtual ICollection<TaskList> TasksList { get; }

    protected sealed override void SetId(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            Notification.AddError(DomainResource.TodoList_Identifier_invalid);
            return;
        }

        Id = id;
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

    public void AddTasksList(TaskList tasksList)
    {
        if (tasksList is null) return;

        if (tasksList.Valid() == false)
        {
            Notification.AddError(DomainResource.MeuEstudo_Thing_invalid, tasksList.Notification);
            return;
        }

        TasksList.Add(tasksList);
    }
}