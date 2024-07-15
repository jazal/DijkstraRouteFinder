namespace DijkstraRouteFinder.Models;

public class PathSegmentDto
{
    public string FromNode { get; set; }
    public string ToNode { get; set; }
    public int Distance { get; set; }
}
