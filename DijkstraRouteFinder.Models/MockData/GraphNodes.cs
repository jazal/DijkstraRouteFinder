namespace DijkstraRouteFinder.Models.MockData;

public static class GraphNodes
{
    public static List<Node> GetGraphNodes()
    {
        var nodeA = new Node { Name = "A" };
        var nodeB = new Node { Name = "B" };
        var nodeC = new Node { Name = "C" };
        var nodeD = new Node { Name = "D" };
        var nodeE = new Node { Name = "E" };
        var nodeF = new Node { Name = "F" };
        var nodeG = new Node { Name = "G" };
        var nodeH = new Node { Name = "H" };
        var nodeI = new Node { Name = "I" };

        nodeA.Edges.Add(new Edge { TargetNode = nodeB, Weight = 4 });
        nodeA.Edges.Add(new Edge { TargetNode = nodeC, Weight = 6 });

        nodeB.Edges.Add(new Edge { TargetNode = nodeA, Weight = 4 });
        nodeB.Edges.Add(new Edge { TargetNode = nodeF, Weight = 2 });

        nodeC.Edges.Add(new Edge { TargetNode = nodeA, Weight = 6 });
        nodeC.Edges.Add(new Edge { TargetNode = nodeD, Weight = 8 });

        nodeD.Edges.Add(new Edge { TargetNode = nodeC, Weight = 8 });
        nodeD.Edges.Add(new Edge { TargetNode = nodeE, Weight = 4 });
        nodeD.Edges.Add(new Edge { TargetNode = nodeG, Weight = 1 });

        nodeE.Edges.Add(new Edge { TargetNode = nodeB, Weight = 2 });
        nodeE.Edges.Add(new Edge { TargetNode = nodeF, Weight = 3 });
        nodeE.Edges.Add(new Edge { TargetNode = nodeD, Weight = 4 });
        nodeE.Edges.Add(new Edge { TargetNode = nodeI, Weight = 8 });

        nodeF.Edges.Add(new Edge { TargetNode = nodeB, Weight = 2 });
        nodeF.Edges.Add(new Edge { TargetNode = nodeE, Weight = 3 });
        nodeF.Edges.Add(new Edge { TargetNode = nodeG, Weight = 4 });
        nodeF.Edges.Add(new Edge { TargetNode = nodeH, Weight = 6 });

        nodeG.Edges.Add(new Edge { TargetNode = nodeD, Weight = 1 });
        nodeG.Edges.Add(new Edge { TargetNode = nodeF, Weight = 4 });
        nodeG.Edges.Add(new Edge { TargetNode = nodeH, Weight = 5 });
        nodeG.Edges.Add(new Edge { TargetNode = nodeI, Weight = 5 });

        nodeH.Edges.Add(new Edge { TargetNode = nodeF, Weight = 6 });
        nodeH.Edges.Add(new Edge { TargetNode = nodeG, Weight = 5 });

        nodeI.Edges.Add(new Edge { TargetNode = nodeG, Weight = 5 });
        nodeI.Edges.Add(new Edge { TargetNode = nodeE, Weight = 8 });

        return new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };
    }
}
