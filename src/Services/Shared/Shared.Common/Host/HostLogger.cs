using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Hosting;

namespace Shared.Common.Host;

public static class HostLogger
{
    public static IHostBuilder UseSerilogHostLogger(this IHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.WithMachineName()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
            .WriteTo.Console());

        return host;
    }
}