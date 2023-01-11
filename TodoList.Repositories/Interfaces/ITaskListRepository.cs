using TodoList.Domain.Entities.TasksList;
using TodoList.Repositories.Abstractions;

namespace TodoList.Repositories.Interfaces;

public interface ITaskListRepository : IRepository<TaskList, Guid> { }