using Microsoft.AspNetCore.Http;

namespace Helper.Helpers;

public static class FileHelper
{
    public static string? SaveFile(IFormFile? file)
    {
        if (file is null || file.Length == 0)
        {
            return null;
        }

        // Define storage folder (adjust path as needed)
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        Directory.CreateDirectory(uploadsFolder); // Ensure directory exists

        // Generate a unique file name
        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        // Save file to disk
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        // Return the relative file path (can be changed to a URL if needed)
        return $"/uploads/{fileName}";
    }
}
