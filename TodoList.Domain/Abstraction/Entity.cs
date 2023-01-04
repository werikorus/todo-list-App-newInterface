using TodoList.Domain.Abstraction.Notifications;

namespace TodoList.Domain.Abstraction;

public abstract class Entity<TId>
    where TId : struct
{
    public readonly INotification Notification = new Notification();
    
    public TId Id { get; protected set; }
    
    public bool Valid() => Notification?.GetErrors?.Any() == false;
    protected abstract void SetId(TId id);
}