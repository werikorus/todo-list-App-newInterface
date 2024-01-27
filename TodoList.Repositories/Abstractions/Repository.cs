using System.Linq.Dynamic.Core;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Abstraction;
using TodoList.Domain.Entities.Lists;
using TodoList.Domain.Entities.TasksList;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Abstractions;
public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public bool Exists(TId id)
        => _dbSet.AsNoTracking().Any(x => Equals(x.Id, id));

    public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
        => await _dbSet.AsNoTracking().AnyAsync(x => Equals(x.Id, id), cancellationToken);

    public void Insert(TEntity entity)
    {
        if (Exists(entity.Id)) return;

        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public virtual async Task InserAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (!await ExistsAsync(entity.Id, cancellationToken).ConfigureAwait(false)) return;

        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(true, cancellationToken);
    }

    public IList<TEntity> SelectAll()
        => _context.Set<TEntity>().ToList();

    public async Task<IList<TEntity>> SelectAllAsync(CancellationToken cancellationToken)
        => await _context.Set<TEntity>().ToListAsync();

    public TEntity SelectById(TId id)
        => _dbSet.Find(id);

    public virtual async Task<TEntity> SelectByIdAsync(TId id, CancellationToken cancellationToken)
        => await _dbSet.FindAsync(new object[] { id }, cancellationToken);

    public void Update(TEntity entity)
    {
        if (Exists(entity.Id)) return;

        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (!await ExistsAsync(entity.Id, cancellationToken).ConfigureAwait(false)) return;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public void Delete(TId id)
    {
        _dbSet.Remove(SelectById(id));
        _context.SaveChanges();
    }

    public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        _dbSet.Remove(await SelectByIdAsync(id, cancellationToken));
        await _context.SaveChangesAsync(true, cancellationToken);
    }

    public User LoginUser(string email, string passsword)
    {
        var user = _context
            .Set<User>()
            .FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Password == passsword);

        return user;
    }
    
    public async Task<User> LoginUserAsync(string email, string passsword, CancellationToken cancellationToken)
    {
        var user = await _context
            .Set<User>()
            .FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper() && x.Password == passsword, cancellationToken: cancellationToken);

        return user;
    }
    
    public IList<List> GetListsByUserId(Guid userId)
    {
        var lists = _context
            .Set<List>()
            .Where(x => x.IdUser == userId)
            .ToList();
        
        return  lists;
    }
    
    public async Task<IList<List>> GetListsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var lists = await _context
            .Set<List>()
            .Where(x => x.IdUser == userId)
            .ToListAsync();
        
        return lists;
    }

    public IList<TaskList> GetTasksByListIdAndUserId(Guid idList, Guid idUser)
    {
        var tasks = _context
            .Set<TaskList>()
            .Where(x => x.IdList == idList && x.IdUser == idUser)
            .ToList();

        return tasks;
    }

    public async Task<IList<TaskList>> GetTasksByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var tasks = await _context
            .Set<TaskList>()
            .Where(x => x.IdUser == userId)
            .ToListAsync();

        return tasks;
    }

    public void DeleteAllListsByUserId (Guid userId)
    {
        _dbSet.Remove((TEntity)GetListsByUserId(userId));    
        _context.SaveChanges();
    }
}