// Program.cs
using DijkstraRouteFinder.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Register services
                services.AddSingleton<IShortestPathService, ShortestPathService>();
                services.AddHostedService<ConsoleApp>();
            })
            .Build();

        await host.RunAsync();
    }
}
