using GifFiles.Api;
using GifFiles.Api.Middleware;
using GifFiles.Application;
using GifFiles.Infrastructure;
using Serilog;
using Shared.Common.Host;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Host.UseSerilogHostLogger();

    builder.Services.AddApi();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseSerilogRequestLogging();
    app.UseErrorHandler();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    try
    {
        Log.Information("Starting web host");
        app.Run();
        return 0;
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Host terminated unexpectedly");
        return 1;
    }
    finally
    {
        Log.CloseAndFlush();
    }
}