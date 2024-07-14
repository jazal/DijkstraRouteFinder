namespace DijkstraRouteFinder.Models;

public class ShortestPathResponseDto
{
    public List<string> NodeNames { get; set; }
    public int Distance { get; set; }
    public List<PathSegmentDto> PathSegments { get; set; }

    public ShortestPathResponseDto()
    {
        NodeNames = new List<string>();
        PathSegments = new List<PathSegmentDto>();
    }
}
