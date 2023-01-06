using AutoMapper;
using TodoList.Domain.Entities.TasksList;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.Services.Services;

public class TasksListService : Service<TaskList, TaskListModel, Guid>, ITasksListService
{
    public TasksListService(ITaskListRepository taskListRepository, IMapper mapper) 
        : base(taskListRepository, mapper) {}
}