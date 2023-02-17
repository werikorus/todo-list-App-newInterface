using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Abstractions;

public class AuthRepository
{
    private readonly DbContext _context;
    private readonly DbSet<User> _dbSet;
    
    protected AuthRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<User>();
    }
    
    public User VerifyUserAndPassword(string email, string password)
    {
        var user = _dbSet.FirstOrDefault(x => x.Email == email && x.Password == password);
        return user;
    }
}