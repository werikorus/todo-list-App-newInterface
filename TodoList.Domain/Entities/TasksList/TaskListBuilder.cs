using TodoList.Domain.Abstraction.Builders;

namespace TodoList.Domain.Entities.TasksList;

public class TaskListBuilder : Builder<TaskListBuilder, TaskList, Guid>, ITasksListBuilder
{    
    private Guid _idList { get; set; }
    private Guid _idUser { get; set; }
    private string _descriptionTask { get; set; }
    private bool _done { get; set; }
    private DateTime _dateCreate { get; set; }
    private DateTime _dateUpdate { get; set; }

    public ITasksListBuilder WithIdList(Guid idList)
    {
        _idList = idList;
        return this;
    }

    public ITasksListBuilder WithDescriptionTask(string descriptionTask)
    {
        _descriptionTask = descriptionTask;
        return this;
    }

    public ITasksListBuilder WithDone(bool done)
    {
        _done = done;
        return this;
    }

    public ITasksListBuilder WithDateCreate(DateTime dateCreate)
    {
        _dateCreate = dateCreate;
        return this;
    }

    public ITasksListBuilder WithDateUpdate(DateTime dateUpdate)
    {
        _dateUpdate = dateUpdate;
        return this;
    }

    public ITasksListBuilder WithIdUser(Guid idUser)
    {
        _idUser = idUser;
        return this;
    }

    public override TaskList Build()
        => new (Id, _idList, _idUser, _descriptionTask, _done, _dateCreate, _dateUpdate);
}