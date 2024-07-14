namespace DijkstraRouteFinder.Models;

public class ShortestPathResponseDto
{
    public List<string> NodeNames { get; set; }
    public int Distance { get; set; }
}
