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
        var graphNodes = GetGraphNodes();
        var result = _shortestPathService.ShortestPath(request.FromNode, request.ToNode, graphNodes);

        if (result == null)
            return NotFound("Path not found");

        return Ok(result);
    }

    // Initialize graph nodes
    private List<Node> GetGraphNodes()
    {
        return GraphNodes.GetGraphNodes();
    }
}

public class ShortestPathRequestDto
{
    public string FromNode { get; set; }
    public string ToNode { get; set; }
}
