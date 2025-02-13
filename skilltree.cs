using Godot;
using System;

public partial class SkillTree : GraphEdit
{
    private Camera2D camera;
    private Godot.Collections.Dictionary<string, Vector2> nodePositions = new Godot.Collections.Dictionary<string, Vector2>();
    private Vector2 defaultPosition = new Vector2(960, 540); // Center of GraphEdit (1920/2, 1080/2)
    private Vector2 defaultZoom = new Vector2(1.0f, 1.0f);  // Default zoom to see everything
    private Vector2 targetPosition;
    private Vector2 targetZoom;
    private float zoomSpeed = 5f;
    private float moveSpeed = 5f;


    public override void _Ready()
    {
        camera = GetNode<Camera2D>("../Camera2D");
        camera.Position = defaultPosition;
        camera.Zoom = defaultZoom;

        // Store the positions of each node for zooming
        string[] nodeNames = { "Player", "Attack", "Passive", "Pet", "Exploration" };
        foreach (string nodeName in nodeNames)
        {
            string path = $"{nodeName}";
            if (HasNode(path))
                nodePositions[nodeName] = GetNode<GraphNode>(path).PositionOffset;
            else
                GD.PrintErr($"Node '{path}' not found! Check your scene hierarchy.");
        }
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
        GD.Print($"Mouse clicked at: {@event.AsText()}");

    }

    private GraphNode GetNodeAtMousePosition(Vector2 mousePosition)
    {
        Vector2 localMousePos = GetViewport().GetMousePosition(); // Get correct position
        foreach (var node in GetChildren())
        {
            if (node is GraphNode graphNode)
            {
                Rect2 nodeRect = new Rect2(graphNode.GlobalPosition, graphNode.Size);
                if (nodeRect.HasPoint(localMousePos))
                {
                    GD.Print($"Node {graphNode.Name} clicked!");
                    return graphNode;
                }
            }
        }
        GD.Print("No node detected under mouse.");
        return null;
    }



    private void ZoomIntoNode(string nodeName)
    {
        if (!nodePositions.ContainsKey(nodeName)) return;

        Vector2 nodePos = nodePositions[nodeName];
        GD.Print($"Zooming into: {nodeName} at {nodePos}");

        targetPosition = nodePos; // Center the camera on the node

        // Prevent extreme zoom values
        targetZoom = new Vector2(Mathf.Clamp(0.5f, 0.2f, 1.5f), Mathf.Clamp(0.5f, 0.2f, 1.5f));
    }

    private void ResetView()
    {
        targetPosition = new Vector2(960, 540); // Center of GraphEdit (1920x1080)
        targetZoom = new Vector2(1.0f, 1.0f); // Default zoom level
    }
}
