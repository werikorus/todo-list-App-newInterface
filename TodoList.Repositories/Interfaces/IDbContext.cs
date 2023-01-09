using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TodoList.Repositories.Interfaces;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    int SaveChanges();
}