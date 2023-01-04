using TodoList.Domain.Abstraction;
using TodoList.Domain.Entities.Lists;

namespace TodoList.Domain.Entities.TasksList;

public class TaskList : Entity<Guid>
{
    internal TaskList(Guid id, Guid idList, string descriptionTask, bool done, DateTime dateCreate, DateTime dateUpdate)
    {
        SetId(id);
        SetIdList(idList);
        SetdescriptionTask(descriptionTask);
        SetDone(done);
        SetDateCreate(dateCreate);
        setDateUpdate(dateUpdate);
    }
    
    public TaskList() { }
    
    public Guid IdList { get; set; }
    public string DescriptionTask { get; set; }
    
    public bool Done { get; set; }
    public DateTime DateCreate { get; set; }
    
    public DateTime DateUpdate { get; set; }
    
    protected sealed override void SetId(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            Notification.AddError("DomainResource.TodoList_Identifier_invalid");
            return;
        }

        Id = id;
    }
    
    private void SetdescriptionTask(string descriptionTask)
    {
        if (descriptionTask.Equals(Guid.Empty))
        {
            Notification.AddError("DomainResource.TodoList_descriptionTask_invalid");
            return;
        }

        DescriptionTask = descriptionTask;
    }
    
    private void SetDone(bool done)
    {
        if (done.Equals(Guid.Empty))
        {
            Notification.AddError("DomainResource.TodoList_done_invalid");
            return;
        }

        Done = done;
    }
    
    private void SetIdList(Guid idList)
    {
        if(idList.Equals(Guid.Empty))
        {
            Notification.AddError("DomainResource.TodoList_idList_invalid");
            return;
        }

        IdList = idList;
    }
    
    private void setDateUpdate(DateTime dateUpdate)
    {
        if(dateUpdate.Equals(Guid.Empty))
        {
            Notification.AddError("DomainResource.TodoList_dateUpdate_invalid");
            return;
        }

        DateUpdate = dateUpdate;
    }

    private void SetDateCreate(DateTime dateCreate)
    {
        if(dateCreate.Equals(Guid.Empty))
        {
            Notification.AddError("DomainResource.TodoList_dateCreate_invalid");
            return;
        }

        DateCreate = dateCreate;
    }
}