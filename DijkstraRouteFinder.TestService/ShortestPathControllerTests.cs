using DijkstraRouteFinder.API.Controllers;
using DijkstraRouteFinder.Models;
using DijkstraRouteFinder.Models.MockData;
using DijkstraRouteFinder.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DijkstraRouteFinder.TestService;

[TestClass]
public class ShortestPathControllerTests
{
    private Mock<IShortestPathService> _mockService;
    private ShortestPathController _controller;

    [TestInitialize]
    public void Setup()
    {
        _mockService = new Mock<IShortestPathService>();
        _controller = new ShortestPathController(_mockService.Object);
    }

    [TestMethod]
    public void GetShortestPath_ReturnsNotFound_WhenPathNotFound()
    {
        // Arrange
        var request = new ShortestPathRequestDto
        {
            FromNode = "NonExistentNode1",
            ToNode = "NonExistentNode2"
        };
        _mockService.Setup(service => service.ShortestPath(request.FromNode, request.ToNode, GraphNodes.GetGraphNodes()))
                    .Returns((ShortestPathResponseDto)null);

        // Act
        var result = _controller.GetShortestPath(request);

        // Assert
        Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        var notFoundResult = result as NotFoundObjectResult;
        Assert.AreEqual("Path not found", notFoundResult.Value);
    }

    [TestMethod]
    public void GetShortestPath_ReturnsOk_WhenPathFound()
    {
        // Arrange
        var request = new ShortestPathRequestDto
        {
            FromNode = "A",
            ToNode = "B"
        };

        var responseDto = new ShortestPathResponseDto
        {
            NodeNames = new List<string> { "A", "B" },
            Distance = 4,
            PathSegments = new List<PathSegmentDto>
                {
                    new PathSegmentDto { FromNode = "A", ToNode = "B", Distance = 4 }
                }
        };

        _mockService.Setup(service => service.ShortestPath(request.FromNode, request.ToNode, It.IsAny<List<Node>>()))
                    .Returns(responseDto);

        // Act
        var result = _controller.GetShortestPath(request);

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        var okResult = result as OkObjectResult;
        var returnValue = okResult.Value as ShortestPathResponseDto;
        Assert.AreEqual(responseDto.NodeNames, returnValue.NodeNames);
        Assert.AreEqual(responseDto.Distance, returnValue.Distance);
        Assert.AreEqual(responseDto.PathSegments, returnValue.PathSegments);
    }

    [TestMethod]
    public void GetShortestPath_ReturnsOk_WhenPathFromItoB()
    {
        // Arrange
        var request = new ShortestPathRequestDto
        {
            FromNode = "I",
            ToNode = "B"
        };

        var responseDto = new ShortestPathResponseDto
        {
            NodeNames = new List<string> { "I", "E", "B" },
            Distance = 10,
            PathSegments = new List<PathSegmentDto>
                {
                    new PathSegmentDto { FromNode = "I", ToNode = "E", Distance = 8 },
                    new PathSegmentDto { FromNode = "E", ToNode = "B", Distance = 2 }
                }
        };

        _mockService.Setup(service => service.ShortestPath(request.FromNode, request.ToNode, It.IsAny<List<Node>>()))
                    .Returns(responseDto);

        // Act
        var result = _controller.GetShortestPath(request);

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        var okResult = result as OkObjectResult;
        var returnValue = okResult.Value as ShortestPathResponseDto;
        Assert.AreEqual(responseDto.NodeNames, returnValue.NodeNames);
        Assert.AreEqual(responseDto.Distance, returnValue.Distance);
        Assert.AreEqual(responseDto.PathSegments, returnValue.PathSegments);
    }

}