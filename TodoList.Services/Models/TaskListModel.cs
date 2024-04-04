namespace TodoList.Services.Models;

public class TaskListModel : BaseModel
{
    public Guid IdList { get; set; }
    public Guid IdUser { get; set; }
    public string DescriptionTask { get; set; }
    public int Done { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
}