using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

public class ApiExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerManager _logger;

    public ApiExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(ex.ToString());
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = ex.Message
            }));
        }
    }
}

public static partial class MiddlewareExtensions
{
    public static IApplicationBuilder UseApiException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiExceptionMiddleware>();
    }
}
