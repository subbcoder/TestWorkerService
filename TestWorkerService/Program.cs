using Serilog;
using TestWorkerService;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .UseWindowsService()
        .ConfigureServices((hostContext, services) =>
        {
            //Logger configuration
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
            services.AddHostedService<Worker>();
        });
}