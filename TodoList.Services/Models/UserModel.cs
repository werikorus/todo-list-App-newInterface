namespace TodoList.Services.Models;

public class UserModel : BaseModel
{
    public string Name { get; set; }
     
    public string Password { get; set; }
     
    public string Email { get; set; }
    
    public DateTime DateCreate { get; set; }
     
    public DateTime DateUpdate { get; set; } 
}