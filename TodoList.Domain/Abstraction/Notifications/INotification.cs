namespace TodoList.Domain.Abstraction.Notifications;

public interface INotification
{
    List<string> GetErrors { get; }
    void AddError(string error, INotification externalNotification);
    void AddError(string error);
    void AddError(INotification notification);
}