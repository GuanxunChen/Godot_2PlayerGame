using Godot;
using System;

public partial class Node2D2 : Node2D
{
    private Camera2D camera;

    public override void _Ready()
    {
        camera = GetNode<Camera2D>("Camera2D");
    }

    public override void _Process(double delta)
    {
        // Zoom in using the '=' key (which is typically the same as the '+' key without Shift)
        if (Input.IsKeyPressed(Key.Equal))
        {
            camera.Zoom *= new Vector2(0.9f, 0.9f); // Zoom out
        }
        
        // Zoom out using the '-' key
        if (Input.IsKeyPressed(Key.Minus))
        {
            camera.Zoom *= new Vector2(1.1f, 1.1f); // Zoom in
        }
    }
}
