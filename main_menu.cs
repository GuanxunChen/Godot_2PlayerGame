using Godot;
using System;

public partial class main_menu : Control
{
    // Path to the game scene
    private const string GameScenePath = "res://game.tscn";

    public override void _Ready()
    {
		// Get Buttons
        Button startButton = GetNode<Button>("Button Menu/Start Game");

		// Buttons pressed
        startButton.Pressed += OnStartButtonPressed;
    }

	/// =====================================
	/// Button Functions
	/// =====================================
    private void OnStartButtonPressed()
    {
        // Load the game scene
        PackedScene gameScene = (PackedScene)GD.Load(GameScenePath);
        
        if (gameScene != null)
        {
            SceneTree tree = GetTree();
            
            Node gameSceneInstance = gameScene.Instantiate();
            
            tree.Root.AddChild(gameSceneInstance);
            tree.CurrentScene.QueueFree();
            tree.CurrentScene = gameSceneInstance;
        }
        else
        {
            GD.PrintErr("Failed to load the game scene at path: " + GameScenePath);
        }
    }
}