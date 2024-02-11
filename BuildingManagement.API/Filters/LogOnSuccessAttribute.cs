using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;

namespace BuildingManagement.API.Filters;
public class LogOnSuccessAttribute : Attribute, IAsyncResultFilter
{
    private readonly string _logDirectory;
    private readonly string _logFileName;

    public LogOnSuccessAttribute(string logDirectory, string logFileName)
    {
        _logDirectory = logDirectory;
        _logFileName = logFileName;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        await next();

        if (context.Result is OkObjectResult)
        {
            var response = context.Result as OkObjectResult;
            var responseData = JsonSerializer.Serialize(response.Value);

            var logPath = Path.Combine(_logDirectory, _logFileName);
            EnsureDirectoryExists(_logDirectory);

            await File.AppendAllTextAsync(logPath, $"{DateTime.Now} - {context.HttpContext.Request.Path} - {responseData}\n", Encoding.UTF8); // UTF-8 karakter kodlaması kullanılıyor.
        }
    }

    private void EnsureDirectoryExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
}
