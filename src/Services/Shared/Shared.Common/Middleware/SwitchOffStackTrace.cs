using Microsoft.AspNetCore.Http;

namespace Shared.Common.Middleware;

internal class SwitchOffStackTrace : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch
        {

        }
    }
}