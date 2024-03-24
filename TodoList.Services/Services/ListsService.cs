using AutoMapper;
using TodoList.Domain.Entities.Lists;
using TodoList.Repositories.Interfaces;
using TodoList.Services.Interfaces;
using TodoList.Services.Models;

namespace TodoList.Services.Services;
public class ListsService : Service<List, ListModel, Guid>, IListService
{
    public ListsService(IListRepository listRepository, IMapper mapper)
        : base(listRepository, mapper) { }
}