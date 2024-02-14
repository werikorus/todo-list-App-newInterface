using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;

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
    public IActionResult Post([FromBody] UploadImageCommand command)
    {
        try
        {
            var urlFile = new
            {
                urlImage = _fileUpload.UploadBase64Image(command.Image, "user-avatar")
            }; 
            return Ok(urlFile);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    public class UploadImageCommand
    {
        public string Image { get; set; }
    }
}