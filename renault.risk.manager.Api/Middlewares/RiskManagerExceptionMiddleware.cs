using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using renault.risk.manager.Domain.Exceptions;

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
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (DbUpdateException ex)
        {
            await HandleExceptionAsync(context, ex);
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

    private Task HandleExceptionAsync(HttpContext context, NotFoundException exception)
    {
        const HttpStatusCode statusCode = HttpStatusCode.NotFound;
        var response = new
        {
            message = "Resource not found.",
            detail = exception.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private Task HandleExceptionAsync(HttpContext context, DbUpdateException exception)
    {
        const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        var response = new
        {
            message = "An error occurred while saving changes to the database.",
            detail = exception.InnerException?.Message
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}