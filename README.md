# Shortest Route Optimizer

Develop an application to calculate the shortest path from one location to another location within connected nodes.

## Hints
- Use Dijkstra’s Algorithm
- Quick video about the algorithm: [Dijkstra’s Algorithm Video](https://www.youtube.com/watch?v=ba4YGd7S-TY)

## Requirements

- ASP.NET Core Web API (.NET 8)
- Vuejs 3
- MSTest for unit testing
- Moq for mocking dependencies

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio or any C# compatible IDE

## Requirements - Backend

1. **Develop an ASP.NET Web API with .NET 8**
   - Create an API that accepts input for the selected FROM and TO nodes.

2. **Take input from the user for the selected FROM and TO nodes**
   - Implement endpoints to receive user inputs for node selection.

3. **Develop an equivalent console app**
   - Reuse the logic from the Web API in a console application that is runnable on your system.

4. **Source node graph contained within a data model**
   - Structure the graph using a data model to represent nodes and edges.

5. **Handle non-bidirectional nodes**
   - Implement logic to support unidirectional edges. For example, from B to E is not possible, but from E to B is.

6. **Expose a method to calculate the shortest route**
   - Method signature example:
     ```csharp
     public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
     {
         // your code here
     }
     ```

7. **Return a DTO containing the results**
   - DTO structure example:
     ```csharp
     public class ShortestPathData
     {
         public List<string> NodeNames { get; set; }
         public int Distance { get; set; }
     }
     ```

8. **Include a list of node names in the order traversed**
   - The result should list nodes in the traversal order from FROM to TO.

9. **Display the list of traversed nodes in comma-separated format**
   - Example: `A, B, C, D`

10. **Display the results to the user**
    - Example output:
      ```
      > fromNodeName = “A”, toNodeName = ”D”: A, B, C, D
      > Total Distance: 10
      ```

## Requirements - Frontend

1. **Develop a Vue application using TypeScript**
   - Consume the endpoints designed in the backend.

2. **User input mode mock-up**
   - Here is the mock-up for user input: [Figma Mock-up](https://www.figma.com/design/VOlrHyAO7hscTdhoUdQG6o/Coding-Challenge?node-id=10454&t=6ZhQ6l3MvknAjaAA-0)

3. **Display the calculated list of traversed nodes**
   - Follow the UI design to display the node traversal list.

4. **Display the aggregate distance travelled**
   - Show the total distance for the path.

## End Result

1. **Demonstrate the application running on your system**
   - Ensure the application runs and is demonstrable on your local system.

## Bonus Points

1. **Create unit test(s) for the solution**
   - Implement unit tests to validate the functionality.

2. **Use the alternate advanced UI design**
   - Out of the 2 UI design options, choose the best one to showcase your skills effectively: [Advanced UI Design](https://www.figma.com/design/VOlrHyAO7hscTdhoUdQG6o/Coding-Challenge?node-id=601000&t=6ZhQ6l3MvknAjaAA-0)




