using AutoMapper;
using TodoList.Domain.Abstraction;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Abstractions;
using TodoList.Services.Abstractions;
using TodoList.Services.Models;

namespace TodoList.Services.Services;

public abstract class Service<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
    where TEntity : Entity<TId>
    where TModel : BaseModel
    where TId : struct
{
    private readonly IMapper _mapper;
    private readonly IRepository<TEntity, TId> _repository;

    protected Service(IRepository<TEntity, TId> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Delete(TId id)
    {
        if (Equals(id, Guid.Empty)) return;
        _repository.Delete(id);
    }

    public async Task DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        if (Equals(id, Guid.Empty)) return;
        await _repository.DeleteAsync(id, cancellationToken);
    }

    public TEntity Edit(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        if (entity.Valid()) _repository.Update(entity);
        return entity;
    }

    public async Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(model);
        if (entity.Valid()) await _repository.UpdateAsync(entity, cancellationToken);
        return entity;
    }

    public bool Exists(TId id) => _repository.Exists(id);

    public async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
        => await _repository.ExistsAsync(id, cancellationToken);

    public IList<TEntity> GetAll() => _repository.SelectAll().ToList();

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await _repository.SelectAllAsync(cancellationToken);

    public TEntity GetById(TId id) => _repository.SelectById(id);

    public async Task<TEntity> GetByIdAsync(TId id, CancellationToken calCancellationToken)
        => await _repository.SelectByIdAsync(id, calCancellationToken);

    public TEntity Save(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        if (entity.Valid()) _repository.Insert(entity);
        return entity;
    }

    public async Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(model);
        if (entity.Valid()) await _repository.InsertAsync(entity, cancellationToken);
        return entity;
    }

    public User LoginUser(string email, string password) 
        => _repository.LoginUser(email, password);

    public async Task<User> LoginUserAsync(string email, string password, CancellationToken cancellationToken)
        => await _repository.LoginUserAsync(email, password, cancellationToken);

    public IList<List> GetListsByUserId(Guid userId)
        => _repository.GetListsByUserId(userId);

    public async Task<IList<List>> GetListsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        => await _repository.GetListsByUserIdAsync(userId, cancellationToken);

    public IList<TaskList> GetTasksByListIdAndUserId(Guid idList, Guid idUser)
        => _repository.GetTasksByListIdAndUserId(idList, idUser);

    public async Task<IList<TaskList>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        => await _repository.GetTasksByUserIdAsync(userId, cancellationToken);
}