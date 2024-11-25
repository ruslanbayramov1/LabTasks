using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;

namespace Slider.BS.Extensions;

public static class FileExtension
{
    public static bool IsValidType(this IFormFile file, string type) => file.ContentType.StartsWith(type);
    public static bool IsValidSize(this IFormFile file, int kb) => file.Length <= kb * 1024;
    public static async Task<string> Upload(this IFormFile file, string filePath)
    {
        if (!Directory.Exists(filePath))
        { 
            Directory.CreateDirectory(filePath);
        }

        string randFile = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string destPath = Path.Combine(filePath, randFile);
        using (Stream stream = File.Create(destPath))
        {
            await file.CopyToAsync(stream);
        }

        return randFile;
    }
    public static async Task<string> Upload(this IFormFile file, string path, string oldFileNameWithExtension)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        File.Delete(Path.Combine(path, oldFileNameWithExtension));
        using (Stream stream = System.IO.File.Create(Path.Combine(path, oldFileNameWithExtension)))
        {
            await file.CopyToAsync(stream);
        }

        return oldFileNameWithExtension;
    }
}
