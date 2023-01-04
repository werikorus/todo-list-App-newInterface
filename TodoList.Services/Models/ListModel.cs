using TodoList.Domain.Entities.TasksList;

namespace TodoList.Services.Models;

public class ListModel : BaseModel
{
    public string DescriptionList  { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }
   
    public virtual ICollection<TaskList> TasksList { get; }
}