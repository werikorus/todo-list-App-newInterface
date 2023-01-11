namespace TodoList.Domain.Abstraction.Builders;

public interface IBuilder<out TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct
{
    TEntity Build();
}