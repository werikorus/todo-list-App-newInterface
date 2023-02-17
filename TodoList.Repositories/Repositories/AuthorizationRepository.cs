using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Users;
using TodoList.Repositories.Interfaces;

namespace TodoList.Repositories.Repositories;

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly DbContext _context;
    private readonly DbSet<User> _dbSet;

    protected AuthorizationRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<User>();
    }
    
    public User VerifyEmailAndPassword(string email, string password)
    {
        var user = _dbSet.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Password == password);
        return user;
    }
}