using FluentValidation;
using Serilog;

namespace Screenshots.Api.Middleware;

public class ErrorLogMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException error)
        {
            Log.Warning(error.Message);
            throw;
        }
        catch (Exception error)
        {
            Log.Error(error.Message);
            throw;
        }
    }
}
