using DijkstraRouteFinder.Models.MockData;
using DijkstraRouteFinder.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class ConsoleApp : IHostedService
{
    private readonly IShortestPathService _shortestPathService;
    private readonly ILogger<ConsoleApp> _logger;

    public ConsoleApp(IShortestPathService shortestPathService, ILogger<ConsoleApp> logger)
    {
        _shortestPathService = shortestPathService;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Console application starting...");

        Console.WriteLine("");
        Console.Write("Enter the FROM node: ");
        var fromNode = Console.ReadLine();

        Console.Write("Enter the TO node: ");
        var toNode = Console.ReadLine();

        var result = _shortestPathService.ShortestPath(fromNode, toNode, GraphNodes.GetGraphNodes());

        if (result != null)
        {
            Console.WriteLine($"Path: {string.Join(", ", result.NodeNames)}");
            Console.WriteLine($"Total Distance: {result.Distance}");
        }
        else
        {
            Console.WriteLine("Path not found");
        }

        Console.WriteLine("");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Console application stopping...");
        return Task.CompletedTask;
    }
}
