using TodoList.Domain.Abstraction;
using TodoList.Services.Models;
using TodoList.Domain.Entities.Users;

namespace TodoList.Services.Abstractions;

public interface IService<TEntity, in TModel, in TId>
    where TEntity: Entity<TId>
    where TModel : BaseModel
    where TId : struct
{
    void Delete(TId id);

    Task DeleteAsync(TId id, CancellationToken cancellationToken);
    
    TEntity Edit(TModel model);
    
    Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken);
    
    bool Exists(TId id);
    
    Task<bool> ExistsAsync(TId id, CancellationToken calCancellationToken);

    IList<TEntity> GetAll();

    Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    TEntity GetById(TId id);

    Task<TEntity> GetByIdAsync(TId id, CancellationToken calCancellationToken);

    TEntity Save(TModel model);

    Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken);
    
    User VerifyUserAndPassword(string dtoEmail, string dtoPassword);
}