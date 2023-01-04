using TodoList.Domain.Entities.TasksList;
using TodoList.Repositories.Abstractions;

namespace TodoList.Repositories;

public interface ITaskListRepository : IRepository<TaskList, Guid> { }