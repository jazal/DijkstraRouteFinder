using DijkstraRouteFinder.Models;
using DijkstraRouteFinder.Models.MockData;
using DijkstraRouteFinder.Services;

namespace DijkstraRouteFinder.Tests;

[TestClass]
public class ShortestPathServiceTests
{
    private IShortestPathService _shortestPathService;

    [TestInitialize]
    public void Setup()
    {
        _shortestPathService = new ShortestPathService();
    }

    [TestMethod]
    public void TestShortestPath_ValidPathAtoF()
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath("A", "F", graphNodes);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Distance);
        CollectionAssert.AreEqual(new List<string> { "A", "B", "F" }, result.NodeNames);
    }

    [DataTestMethod]
    [DataRow("A", "I", 15, new string[] { "A", "B", "F", "G", "I" })]
    [DataRow("I", "A", 14, new string[] { "I", "E", "B", "A" })]
    [DataRow("H", "C", 14, new string[] { "H", "G", "D", "C" })]
    [DataRow("G", "A", 10, new string[] { "G", "F", "B", "A" })]
    [DataRow("A", "E", 9, new string[] { "A", "B", "F", "E" })]
    [DataRow("E", "A", 6, new string[] { "E", "B", "A" })]
    public void TestShortestPath(string startNode, string endNode, int expectedDistance, string[] expectedPath)
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath(startNode, endNode, graphNodes);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedDistance, result.Distance);
        CollectionAssert.AreEqual(expectedPath, result.NodeNames);
    }

    [TestMethod]
    public void TestShortestPath_NoPathAvailableForToNode()
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath("A", "Z", graphNodes);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestShortestPath_NoPathAvailable()
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath("X", "Z", graphNodes);

        // Assert
        Assert.IsNull(result);
    }

    private List<Node> GetTestGraphNodes()
    {
        return GraphNodes.GetGraphNodes();
    }
}
