using System.Net;
using System.Text.Json;

namespace renault.risk.manager.Api.Middlewares;

public class RiskManagerExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public RiskManagerExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var response = new
        {
            message = "An unexpected error occurred",
            detail = exception.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}