namespace TodoList.Services.Interfaces;

public interface IFileUpload
{
    public string UploadBase64Image(string base64Image, string container);
}