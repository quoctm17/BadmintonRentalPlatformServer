using BadmintonRentalPlatformAPI.Configuration.Domain;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace BadmintonRentalPlatformAPI.Configuration;

public class ImageService : IImageService
{

    private readonly Cloudinary _cloudinary;

    public ImageService(IOptions<CloudinarySetting> options)
    {
        var account = new Account(options.Value.CloudName, options.Value.ApiKey, options.Value.ApiSecret);
        _cloudinary = new Cloudinary(account);
    }
    
    public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
    {
        var result = await _cloudinary.UploadAsync(
            new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName,
                Folder = "badminton-rental-platform"
            }
        );
        if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return result;
        }
        return null;
    }

    public Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        throw new NotImplementedException();
    }
}