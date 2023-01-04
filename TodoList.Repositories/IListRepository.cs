using TodoList.Repositories.Abstractions;
using TodoList.Domain.Entities.Lists;

namespace TodoList.Repositories;

public interface IListRepository : IRepository<List, Guid> { }