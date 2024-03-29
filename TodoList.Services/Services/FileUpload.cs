using Azure.Storage.Blobs;
using System.Text.RegularExpressions;
using TodoList.Services.Interfaces;


namespace TodoList.Services.Services;

public class FileUpload : IFileUpload
{
    public string UploadBase64Image(string base64Image, string container)
    {
        var fileName = Guid.NewGuid() + ".jpg";

        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

        byte[] imageBytes = Convert.FromBase64String(data);

        var blobClient = new BlobClient(Settings.BlobKey, container, fileName);

        using (var stream = new MemoryStream(imageBytes))
        {
            blobClient.Upload(stream);
        }

        return blobClient.Uri.AbsoluteUri;
    }
}


//https://youtu.be/61r7A8drcN8