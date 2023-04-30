using TodoList.Domain.Abstraction;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Abstractions;

public interface IRepository<TEntity, in Tid>
    where TEntity : Entity<Tid>
    where Tid : struct
{
    void Delete(Tid id);
    Task DeleteAsync(Tid id, CancellationToken cancellationToken);

    bool Exists(Tid id);
    Task<bool> ExistsAsync(Tid id, CancellationToken cancellationToken);

    void Insert(TEntity entity);
    Task InserAsync(TEntity entity, CancellationToken cancellationToken);

    IList<TEntity> SelectAll();

    Task<IList<TEntity>> SelectAllAsync(CancellationToken cancellationToken);

    TEntity SelectById(Tid id);
    Task<TEntity> SelectByIdAsync(Tid id, CancellationToken cancellationToken);

    void Update(TEntity entity);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    User LoginUser(string email, string password);
}