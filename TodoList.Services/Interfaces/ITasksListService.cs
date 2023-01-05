using TodoList.Domain.Entities.TasksList;
using TodoList.Services.Models;

namespace TodoList.Services.Interfaces;

public interface ITasksListService : IService<TaskList, TaskListModel, Guid> {}
