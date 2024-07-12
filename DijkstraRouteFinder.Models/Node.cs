namespace DijkstraRouteFinder.Models;

public class Node
{
    public string Name { get; set; }
    public List<Edge> Edges { get; set; } = new List<Edge>();
}
