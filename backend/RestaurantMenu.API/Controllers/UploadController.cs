using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.API.Services;
using System.Security.Claims;

namespace RestaurantMenu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UploadController : ControllerBase
{
    private readonly IFileUploadService _fileUploadService;

    public UploadController(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    [HttpPost("image")]
    [RequestSizeLimit(10 * 1024 * 1024)] // 10MB
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile? file)
    {
        // Try to get file from form if not in parameter
        if (file == null)
        {
            file = Request.Form.Files.FirstOrDefault();
        }

        if (file == null || file.Length == 0)
        {
            Console.WriteLine("No file received in request");
            Console.WriteLine($"Form keys: {string.Join(", ", Request.Form.Keys)}");
            Console.WriteLine($"Files count: {Request.Form.Files.Count}");
            return BadRequest(new { message = "No file uploaded" });
        }

        // Log file details for debugging
        Console.WriteLine($"Upload attempt - FileName: '{file.FileName ?? "null"}', ContentType: '{file.ContentType ?? "null"}', Length: {file.Length}");

        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var fileUrl = await _fileUploadService.UploadImageAsync(file, userId);
            Console.WriteLine($"Upload successful - URL: {fileUrl}");
            return Ok(new { url = fileUrl });
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Upload validation error: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Upload error: {ex.Message}");
            Console.WriteLine($"Error type: {ex.GetType().Name}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return StatusCode(500, new { message = "Upload failed", error = ex.Message });
        }
    }

    [HttpGet("{fileName}")]
    [AllowAnonymous]
    public IActionResult GetFile(string fileName)
    {
        try
        {
            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            var filePath = Path.Combine(uploadsPath, fileName);
            
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(new { message = "File not found" });
            }
            
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/octet-stream";
            
            // Determine content type from extension
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            contentType = extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
            
            return File(fileBytes, contentType);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error serving file", error = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFile([FromQuery] string url)
    {
        try
        {
            await _fileUploadService.DeleteFileAsync(url);
            return Ok(new { message = "File deleted successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

