using TodoList.Domain.Abstraction.Builders;
using TodoList.Domain.Entities.TasksList;

namespace TodoList.Domain.Entities.TasksList;

public class TaskListBuilder : Builder<TaskListBuilder, TaskList, Guid>, ITasksListBuilder 
{
    private ITasksListBuilder _tasksListBuilderImplementation;
    public Guid _idList { get; set; }
    public Guid _idUser { get; set; }
    public string _descriptionTask { get; set; }
    public bool _done { get; set; }
    public DateTime _dateCreate { get; set; }
    public DateTime _dateUpdate { get; set; }
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
        => new TaskList(Id, _idList, _idUser, _descriptionTask, _done, _dateCreate, _dateUpdate);
}