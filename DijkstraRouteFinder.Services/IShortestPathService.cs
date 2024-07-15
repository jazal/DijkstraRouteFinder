using DijkstraRouteFinder.Models;

namespace DijkstraRouteFinder.Services;

public interface IShortestPathService
{
    ShortestPathResponseDto ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes);
}
