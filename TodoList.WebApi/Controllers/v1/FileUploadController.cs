using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Services;
using TodoList.WebApi.Controllers;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class FileUploadController : TodoListControllerBase
{
    public string Post([FromBody] UploadImageCommand command)
    {
        var uploadServices = new FileUpload();
        return uploadServices.UploadBase64Image(command.Image, "user-avatar");
    }
    
    public class UploadImageCommand
    {
        public string Image { get; set; }
    }
}