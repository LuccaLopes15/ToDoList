using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ToDoList.Shared.Domain.Common.Exceptions;

namespace ToDoList.Server.Api.Setup.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu uma exceção não tratada: {Message}", ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError; 
        string message = "Um erro inesperado ocorreu. Tente novamente mais tarde.";

        var errorResponse = new
        {
            title = message,
            status = (int)statusCode,
            errors = (object?)null
        };

        if (exception is DomainException domainValidationException)
        {
            statusCode = HttpStatusCode.BadRequest;
            errorResponse = new
            {
                title = domainValidationException.Message,
                status = (int)statusCode,
                errors = (object?)null
            };
        }
        else if (exception is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            errorResponse = new
            {
                title = exception.Message,
                status = (int)statusCode,
                errors = (object?)null
            };
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(errorResponse);
        return context.Response.WriteAsync(result);
    }
}
