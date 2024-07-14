using DijkstraRouteFinder.Models;
using DijkstraRouteFinder.Models.MockData;
using DijkstraRouteFinder.Services;
using Microsoft.AspNetCore.Mvc;

namespace DijkstraRouteFinder.API.Controllers;

public class ShortestPathController : BaseApiController
{
    private readonly IShortestPathService _shortestPathService;

    public ShortestPathController(IShortestPathService shortestPathService)
    {
        _shortestPathService = shortestPathService;
    }

    [HttpPost]
    public IActionResult GetShortestPath([FromBody] ShortestPathRequestDto request)
    {
        var graphNodes = GetGraphNodes(); // Retrieve graph nodes from a data source
        var result = _shortestPathService.ShortestPath(request.FromNode, request.ToNode, graphNodes);

        if (result == null)
            return NotFound("Path not found");

        return Ok(result);
    }

    private List<Node> GetGraphNodes()
    {
        // Initialize your graph nodes here or fetch from a data source
        return GraphNodes.GetGraphNodes();
    }
}

public class ShortestPathRequestDto
{
    public string FromNode { get; set; }
    public string ToNode { get; set; }
}
