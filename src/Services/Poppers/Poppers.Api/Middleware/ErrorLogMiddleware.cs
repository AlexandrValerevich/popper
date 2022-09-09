using FluentValidation;
using Poppers.Application.Common.Exceptions;
using Poppers.Domain.Exceptions;
using Serilog;

namespace Poppers.Api.Middleware;

public class ErrorLogMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (AppException error)
        {
            Log.Information(error.Message);
            throw;
        }
        catch (DomainException error)
        {
            Log.Information(error.Message);
            throw;
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
