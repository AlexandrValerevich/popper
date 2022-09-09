namespace GifFiles.Api.Middleware;

public static class Extensions
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlerMiddleware>();
    }

    public static IApplicationBuilder UseErrorLog(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorLogMiddleware>();
    }
}