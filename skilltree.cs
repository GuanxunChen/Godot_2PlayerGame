using Godot;

public partial class SkillTree : GraphEdit
{
    private Camera2D camera;
    private Godot.Collections.Dictionary<string, Vector2> nodePositions = new Godot.Collections.Dictionary<string, Vector2>();


    public override void _Ready()
    {
        camera = GetNode<Camera2D>("Camera2D");

        // Store the positions of each node for zooming
        nodePositions["Player"] = GetNode<GraphNode>("PlayerNode").PositionOffset;
        nodePositions["Attack"] = GetNode<GraphNode>("AttackNode").PositionOffset;
        nodePositions["Passive"] = GetNode<GraphNode>("PassiveNode").PositionOffset;
        nodePositions["Pet"] = GetNode<GraphNode>("PetNode").PositionOffset;
        nodePositions["Exploration"] = GetNode<GraphNode>("ExplorationNode").PositionOffset;
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            GraphNode clickedNode = GetNodeAtMousePosition(mouseEvent.Position);
            if (clickedNode != null)
            {
                ZoomIntoNode(clickedNode.Name);
            }
        }
    }

    private GraphNode GetNodeAtMousePosition(Vector2 mousePosition)
    {
        foreach (var node in GetChildren())
        {
            if (node is GraphNode graphNode)
            {
                Rect2 nodeRect = new Rect2(graphNode.PositionOffset, graphNode.Size);
                if (nodeRect.HasPoint(mousePosition))
                {
                    return graphNode;
                }
            }
        }
        return null;
    }

    private void ZoomIntoNode(string nodeName)
    {
        if (!nodePositions.ContainsKey(nodeName)) return;

        Vector2 targetPosition = nodePositions[nodeName];
        
        camera.Position = targetPosition; // Move camera to the node
        camera.Zoom = new Vector2(0.5f, 0.5f); // Zoom in smoothly
    }
}
