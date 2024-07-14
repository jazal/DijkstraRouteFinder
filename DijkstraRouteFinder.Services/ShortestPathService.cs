using DijkstraRouteFinder.Models;

namespace DijkstraRouteFinder.Services;

public class ShortestPathService : IShortestPathService
{
    public ShortestPathResponseDto ShortestPathV1(string fromNodeName, string toNodeName, List<Node> graphNodes)
    {
        // Implement Dijkstra's Algorithm
        var shortestPaths = new Dictionary<Node, (int Distance, List<string> Path)>();
        var unvisitedNodes = new List<Node>(graphNodes);

        var startNode = graphNodes.First(n => n.Name == fromNodeName);
        shortestPaths[startNode] = (0, new List<string> { startNode.Name });

        while (unvisitedNodes.Count > 0)
        {
            var currentNode = unvisitedNodes
                .Where(n => shortestPaths.ContainsKey(n))
                .OrderBy(n => shortestPaths[n].Distance)
                .FirstOrDefault();

            if (currentNode == null || currentNode.Name == toNodeName)
                break;

            unvisitedNodes.Remove(currentNode);

            foreach (var edge in currentNode.Edges)
            {
                var neighbor = edge.TargetNode;
                var newDist = shortestPaths[currentNode].Distance + edge.Weight;

                if (!shortestPaths.ContainsKey(neighbor) || newDist < shortestPaths[neighbor].Distance)
                {
                    shortestPaths[neighbor] = (newDist, new List<string>(shortestPaths[currentNode].Path) { neighbor.Name });
                }
            }
        }

        var endNode = graphNodes.First(n => n.Name == toNodeName);
        return shortestPaths.ContainsKey(endNode) ?
            new ShortestPathResponseDto { NodeNames = shortestPaths[endNode].Path, Distance = shortestPaths[endNode].Distance } :
            null;
    }

    public ShortestPathResponseDto ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
    {
        var shortestPaths = new Dictionary<Node, (int Distance, List<string> Path, List<PathSegmentDto> Segments)>();
        var unvisitedNodes = new List<Node>(graphNodes);

        var startNode = graphNodes.First(n => n.Name == fromNodeName);
        shortestPaths[startNode] = (0, new List<string> { startNode.Name }, new List<PathSegmentDto>());

        while (unvisitedNodes.Count > 0)
        {
            var currentNode = unvisitedNodes
                .Where(n => shortestPaths.ContainsKey(n))
                .OrderBy(n => shortestPaths[n].Distance)
                .FirstOrDefault();

            if (currentNode == null || currentNode.Name == toNodeName)
                break;

            unvisitedNodes.Remove(currentNode);

            foreach (var edge in currentNode.Edges)
            {
                var neighbor = edge.TargetNode;
                var newDist = shortestPaths[currentNode].Distance + edge.Weight;
                var newSegments = new List<PathSegmentDto>(shortestPaths[currentNode].Segments)
                {
                    new PathSegmentDto
                    {
                        FromNode = currentNode.Name,
                        ToNode = neighbor.Name,
                        Distance = edge.Weight
                    }
                };

                if (!shortestPaths.ContainsKey(neighbor) || newDist < shortestPaths[neighbor].Distance)
                {
                    shortestPaths[neighbor] = (newDist, new List<string>(shortestPaths[currentNode].Path) { neighbor.Name }, newSegments);
                }
            }
        }

        var endNode = graphNodes.First(n => n.Name == toNodeName);
        return shortestPaths.ContainsKey(endNode) ?
            new ShortestPathResponseDto
            {
                NodeNames = shortestPaths[endNode].Path,
                Distance = shortestPaths[endNode].Distance,
                PathSegments = shortestPaths[endNode].Segments
            } :
            null;
    }
}

