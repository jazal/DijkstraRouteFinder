using DijkstraRouteFinder.Models;

namespace DijkstraRouteFinder.Services;

public interface IShortestPathService
{
    ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes);
}
