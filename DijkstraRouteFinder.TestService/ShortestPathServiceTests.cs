using DijkstraRouteFinder.Models;
using DijkstraRouteFinder.Models.MockData;
using DijkstraRouteFinder.Services;

namespace DijkstraRouteFinder.TestService;

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
    public void Test_ValidPathAtoF()
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
    
    [TestMethod]
    public void Test_ValidPathAtoI()
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath("A", "I", graphNodes);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(15, result.Distance);
        CollectionAssert.AreEqual(new List<string> { "A", "B", "F", "G", "I" }, result.NodeNames);
    }
    
    [TestMethod]
    public void Test_ValidPathItoA()
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath("I", "A", graphNodes);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(14, result.Distance);
        CollectionAssert.AreEqual(new List<string> { "I", "E", "B", "A" }, result.NodeNames);
    }

    [TestMethod]
    public void Test_NoPathAvailableForToNode()
    {
        // Arrange
        var graphNodes = GetTestGraphNodes();

        // Act
        var result = _shortestPathService.ShortestPath("A", "Z", graphNodes);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Test_NoPathAvailable()
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
