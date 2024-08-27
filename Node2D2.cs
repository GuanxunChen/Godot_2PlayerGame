using Godot;
using System;

public partial class Node2D2 : Node2D
{
    private Camera2D camera;
    private TextureRect character1;
    private TextureRect character2;


    public override void _Ready()
    {
        camera = GetNode<Camera2D>("Camera2D");

        character1 = GetNode<TextureRect>("Character1");
        character2 = GetNode<TextureRect>("Character2");
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
        if (Input.IsKeyPressed(Key.A))
        {
            character1.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
        }
    }
}
