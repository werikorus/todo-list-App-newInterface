using TodoList.Domain.Entities.Users;
using TodoList.Services.Abstractions;
using TodoList.Services.Models;

namespace TodoList.Services.Interfaces;

public interface ITokenService
{
   public static string GenerateToken(User user);
}