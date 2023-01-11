namespace TodoList.Domain.Abstraction.Notifications;

public class Notification : INotification
{
    public Notification()
    {
        GetErrors = new List<string>();
    }
    public List<string> GetErrors { get; }

    public string Error => string.Join(", ", GetErrors);

    public void AddError(string error) => GetErrors.Add(error);
    
    public void AddError(INotification notification) => AddErrors(notification?.GetErrors!);
    
    public void AddError(string error, INotification externalNotification)
    {
        AddError(error);
        AddErrors(externalNotification?.GetErrors!);
    }

    public void AddErrors(IEnumerable<INotification> notifications)
        => AddErrors(notifications?.SelectMany(notification => notification.GetErrors)!);

    public void AddErrors(IEnumerable<string> errors)
    {
        if(errors is null) return;
        GetErrors.AddRange(errors);
    }
}