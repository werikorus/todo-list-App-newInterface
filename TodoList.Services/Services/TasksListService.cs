using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.Services.Services;

public class TasksListService : ITasksListService
{
    private ITasksListService _tasksListServiceImplementation;
    public void Delete(Guid id)
    {
        _tasksListServiceImplementation.Delete(id);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _tasksListServiceImplementation.DeleteAsync(id, cancellationToken);
    }

    public TaskList Edit(TaskListModel model)
    {
        return _tasksListServiceImplementation.Edit(model);
    }

    public Task<TaskList> EditAsync(TaskListModel model, CancellationToken cancellationToken)
    {
        return _tasksListServiceImplementation.EditAsync(model, cancellationToken);
    }

    public bool Exists(Guid id)
    {
        return _tasksListServiceImplementation.Exists(id);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken calCancellationToken)
    {
        return _tasksListServiceImplementation.ExistsAsync(id, calCancellationToken);
    }

    public IList<TaskList> GetAll()
    {
        return _tasksListServiceImplementation.GetAll();
    }

    public Task<IList<TaskList>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _tasksListServiceImplementation.GetAllAsync(cancellationToken);
    }

    public TaskList GetById(Guid id)
    {
        return _tasksListServiceImplementation.GetById(id);
    }

    public Task<TaskList> GetByIdAsync(Guid id, CancellationToken calCancellationToken)
    {
        return _tasksListServiceImplementation.GetByIdAsync(id, calCancellationToken);
    }

    public TaskList Save(TaskListModel model)
    {
        return _tasksListServiceImplementation.Save(model);
    }

    public Task<TaskList> SaveAsync(TaskListModel model, CancellationToken cancellationToken)
    {
        return _tasksListServiceImplementation.SaveAsync(model, cancellationToken);
    }
}