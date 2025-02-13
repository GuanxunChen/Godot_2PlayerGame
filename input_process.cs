using Godot;
using System;

public partial class input_process : Node2D
{
    private Camera2D camera;
    private TextureRect character1;
    private TextureRect character2;
    private Sprite2D sprite2d;

    // This method is called when the node is 'ready', which means that
    // all children have entered the scene tree and are initialized.
    // It is called once when the node is ready.
    public override void _Ready()
    {
        // Get the Camera2D node from the scene tree and assign it to the 'camera' variable.
        // The 'GetNode' method searches for a node with the specified name in the scene tree.
        // The Camera2D node is used to control the viewport of the game.
        camera = GetNode<Camera2D>("Player/Camera2D");

        // Get the two TextureRect nodes from the scene tree and assign them to the 'character1' and 'character2' variables.
        // The 'GetNode' method searches for a node with the specified name in the scene tree.
        // The TextureRect nodes are used to display the characters in the game.
        character1 = GetNode<TextureRect>("Character1");
        character2 = GetNode<TextureRect>("Character2");

        // Get the Sprite2D node from the scene tree and assign it to the 'Zorua' variable.
        // The 'GetNode' method searches for a node with the specified name in the scene tree.
        // The Sprite2D node is used to display the Zorua character in the game.
        sprite2d = GetNode<Sprite2D>("Player/Sprite2D");
    }

    // This method is called every frame. The 'delta' parameter is the time
    // elapsed since the previous frame in seconds.
    // The '_Process' method is used to handle user input and update the game state.
    public override void _Process(double delta)
    {
        float speed = 10.0f;
        // Check if the '=' key is pressed. This is typically the same as the '+' key without Shift.
        // The 'IsKeyPressed' method checks if a key is currently pressed.
        if (Input.IsKeyPressed(Key.Equal))
        {
            // Zoom out by reducing the 'Zoom' property of the 'Camera2D' node.
            // The 'Zoom' property controls the zoom level of the camera.
            // The '*=' operator is used to multiply the current zoom level by a factor of 0.9.
            camera.Zoom *= new Vector2(0.9f, 0.9f); 
        }
        
        // Check if the '-' key is pressed.
        if (Input.IsKeyPressed(Key.Minus))
        {
            // Zoom in by increasing the 'Zoom' property of the 'Camera2D' node.
            // The '*=' operator is used to multiply the current zoom level by a factor of 1.1.
            camera.Zoom *= new Vector2(1.1f, 1.1f); 
        }
        
        // Check if the 'Q' key is pressed.
        if (Input.IsKeyPressed(Key.Q))
        {
            // Change the color of the 'Character1' node to a shade of gray.
            // The 'Modulate' property controls the color of a node.
            // The 'new Color' constructor is used to create a new color with specific RGBA values.
            // The '1' value for the alpha channel means the node will be completely opaque.
            character1.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
        }
/*
        if (Input.IsKeyPressed(Key.W))
        {
            Zorua.Position += new Vector2(0, -speed);
            camera.Position += new Vector2(0, -speed);
        }
        if (Input.IsKeyPressed(Key.A))
        {
            Zorua.Position += new Vector2(-speed, 0);
            camera.Position += new Vector2(-speed, 0);
        }
        if (Input.IsKeyPressed(Key.S))
        {
            Zorua.Position += new Vector2(0, speed);
            camera.Position += new Vector2(0, speed);
        }
        if (Input.IsKeyPressed(Key.D))
        {
            Zorua.Position += new Vector2(speed, 0);
            camera.Position += new Vector2(speed, 0);
        }*/
    }
    
}
