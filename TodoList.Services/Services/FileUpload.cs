using System.Text.RegularExpressions;
using Azure.Storage.Blobs;
using TodoList.Services.Interfaces;


namespace TodoList.Services.Services;

public class FileUpload : IFileUpload
{
    public string UploadBase64Image(string base64Image, string container)
    {
        //Generate a random name to image
        var fileName = Guid.NewGuid() + ".jpg";
        
        //clear the sent cache
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");
        
        //generate a Bytes array
        byte[] imageBytes = Convert.FromBase64String(data);
        
        // defines the blob that the image will be storage
        var blobClient = new BlobClient(Settings.BlobKey, container, fileName);
        
        //send the image
        using (var stream = new MemoryStream(imageBytes))
        {
            blobClient.Upload(stream);
        }

        return blobClient.Uri.AbsoluteUri;
    }
}


//https://youtu.be/61r7A8drcN8