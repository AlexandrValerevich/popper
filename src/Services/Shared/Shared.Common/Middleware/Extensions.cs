using Microsoft.AspNetCore.Builder;

namespace Shared.Common.Middleware;

public static class Extensions
{
    public static IApplicationBuilder UseSwitchOffStackTrace(this IApplicationBuilder app)
    {
        app.UseMiddleware<SwitchOffStackTrace>();
        return app;
    }
}