using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using TodoList.Services.Services;

namespace TodoList.WebApi.Controllers.v1;

[ApiVersion("1")]
public class FileUploadController : TodoListControllerBase
{
    private readonly IFileUpload _fileUpload;
        
    public FileUploadController(IFileUpload fileUpload)
    {
        _fileUpload = fileUpload;
    }

    [HttpPost]
    public string Post([FromBody] UploadImageCommand command)
    {
        try
        {  
            var urlImg = _fileUpload.UploadBase64Image(command.Image, "user-avatar");
            return urlImg;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
    
    public class UploadImageCommand
    {
        public string Image { get; set; }
    }
}