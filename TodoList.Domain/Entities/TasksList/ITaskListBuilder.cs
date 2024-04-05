using TodoList.Domain.Abstraction.Builders;

namespace TodoList.Domain.Entities.TasksList;

public interface ITasksListBuilder : IBuilder<TaskList, Guid>
{
    ITasksListBuilder WithIdList(Guid idList);
    ITasksListBuilder WithDescriptionTask(string descriptionTask);
    ITasksListBuilder WithDone(int done);
    ITasksListBuilder WithDateCreate(DateTime dateCreate);
    ITasksListBuilder WithDateUpdate(DateTime dateUpdate);
    ITasksListBuilder WithIdUser(Guid idUser);
}