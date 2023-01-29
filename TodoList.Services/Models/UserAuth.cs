namespace TodoList.Services.Models;

public class UserAuth
{
    public string Username { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }

    public UserAuth(string username, string role, string password)
    {
        Username = username;
        Role = role;
        Password = password;
    }
}