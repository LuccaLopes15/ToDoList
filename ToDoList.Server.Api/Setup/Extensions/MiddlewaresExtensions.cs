using ToDoList.Server.Api.Setup.Middlewares;

namespace ToDoList.Server.Api.Setup.Extensions;

public static class MiddlewaresExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
