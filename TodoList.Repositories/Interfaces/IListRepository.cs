using TodoList.Domain.Entities.Lists;
using TodoList.Repositories.Abstractions;

namespace TodoList.Repositories.Interfaces;

public interface IListRepository : IRepository<List, Guid> { }