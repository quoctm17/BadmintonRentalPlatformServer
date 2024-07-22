using CloudinaryDotNet.Actions;

namespace BadmintonRentalPlatformAPI.Configuration;

public interface IImageService
{
    public Task<ImageUploadResult> UploadImageAsync(IFormFile formFile);
    public Task<DeletionResult> DeletePhotoAsync(string publicId);
}