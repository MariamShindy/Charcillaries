using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Charcillaries.Core.Features.Images;

public interface IImageService
{
    public Task<string> UploadImage(IFormFile file);

    public Task<bool> UploadImage(IFormFile file, string fileName);

    public Task<bool> DeleteImage(string fileName);

    public Task<string> GetImageUrl(string fileName);
}

public class ImageService(IMinioClient minioClient) : IImageService
{
    public async Task<string> UploadImage(IFormFile file)
    {
        var fileName = Guid.NewGuid().ToString();
        await using var stream = file.OpenReadStream();

        var image = await Image.LoadAsync(stream);

        image.Mutate(x => x.Resize(0, 256, KnownResamplers.Lanczos3));
        await using var memoryStream = new MemoryStream();
        await image.SaveAsWebpAsync(memoryStream, new WebpEncoder { Quality = 75 });

        memoryStream.Position = 0;
        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(Constants.BucketName)
            .WithObject(fileName)
            .WithObjectSize(memoryStream.Length)
            .WithStreamData(memoryStream)
            .WithContentType("image/webp")
        );
        return fileName;
    }

    public async Task<bool> UploadImage(IFormFile file, string fileName)
    {
        await using var stream = file.OpenReadStream();

        var image = await Image.LoadAsync(stream);

        image.Mutate(x => x.Resize(0, 256, KnownResamplers.Lanczos3));
        await using var memoryStream = new MemoryStream();
        await image.SaveAsWebpAsync(memoryStream, new WebpEncoder { Quality = 75 });

        memoryStream.Position = 0;
        try
        {
            await minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(Constants.BucketName)
                .WithObject(fileName)
                .WithObjectSize(memoryStream.Length)
                .WithStreamData(memoryStream)
                .WithContentType("image/webp")
            );
        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteImage(string fileName)
    {
        try
        {
            await minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                .WithBucket(Constants.BucketName)
                .WithObject(fileName)
            );
        }
        catch
        {
            return false;
        }

        return true;
    }

    public Task<string> GetImageUrl(string fileName)
    {
        return minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithBucket(Constants.BucketName)
            .WithExpiry(60 * 60 * 24)
            .WithObject(fileName)
        );
    }
}