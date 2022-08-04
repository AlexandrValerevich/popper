using Poppers.Api;
using Poppers.Application;
using Poppers.Domain;
using Poppers.Infrastructure;
using Serilog;
using Shared.Common.Host;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApi();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddDomain();

    builder.Host.UseSerilogHostLogger();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseSerilogRequestLogging();

    app.UseHsts();
    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.UseExceptionHandler("/error");
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