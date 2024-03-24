using TodoList.Domain.Entities.Lists;
using TodoList.Services.Abstractions;
using TodoList.Services.Models;

namespace TodoList.Services.Interfaces;

public interface IListService : IService<List, ListModel, Guid> { }
