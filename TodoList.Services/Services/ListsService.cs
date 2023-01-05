using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.Users;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.Services.Services;

public class ListsService : IListService
{
    private IListService _listServiceImplementation;
    public void Delete(Guid id)
    {
        _listServiceImplementation.Delete(id);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _listServiceImplementation.DeleteAsync(id, cancellationToken);
    }

    public List Edit(ListModel model)
    {
        return _listServiceImplementation.Edit(model);
    }

    public Task<List> EditAsync(ListModel model, CancellationToken cancellationToken)
    {
        return _listServiceImplementation.EditAsync(model, cancellationToken);
    }

    public bool Exists(Guid id)
    {
        return _listServiceImplementation.Exists(id);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken calCancellationToken)
    {
        return _listServiceImplementation.ExistsAsync(id, calCancellationToken);
    }

    public IList<List> GetAll()
    {
        return _listServiceImplementation.GetAll();
    }

    public Task<IList<List>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _listServiceImplementation.GetAllAsync(cancellationToken);
    }

    public List GetById(Guid id)
    {
        return _listServiceImplementation.GetById(id);
    }

    public Task<List> GetByIdAsync(Guid id, CancellationToken calCancellationToken)
    {
        return _listServiceImplementation.GetByIdAsync(id, calCancellationToken);
    }

    public List Save(ListModel model)
    {
        return _listServiceImplementation.Save(model);
    }

    public Task<List> SaveAsync(ListModel model, CancellationToken cancellationToken)
    {
        return _listServiceImplementation.SaveAsync(model, cancellationToken);
    }
}