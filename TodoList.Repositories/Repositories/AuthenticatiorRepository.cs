using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Users;
using TodoList.Domain.Abstraction;
using TodoList.Repositories.Contexts;

namespace TodoList.Repositories.Repositories;

public class AuthorizationRepository 
{
   
    private  TodoListContext _context;
    private static DbSet<User>? _dbSet;

    protected AuthorizationRepository(TodoListContext context)
    {
        _context = context;
        _dbSet = context.Set<User>();
    }
    
    public static User VerifyEmailAndPassword(string email, string password)
    {
        try
        {
            var user = _dbSet
                .Where(x => x.Email.ToUpper() == email.ToUpper() && x.Password == password)
                .FirstOrDefault();
            
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}