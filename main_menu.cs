using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class main_menu : Control
{
    // Linking to the game scene
    private const string GameScenePath = "res://game.tscn";

    public override void _Ready()
    {
		// Linking to Buttons
        Button startButton = GetNode<Button>("Button Menu/Start Game");
        Button loadButton = GetNode<Button>("Button Menu/Load Game");
        Button settingButton = GetNode<Button>("Button Menu/Settings");
        Button quitButton = GetNode<Button>("Button Menu/Quit");

		// Buttons pressed
        startButton.Pressed += OnStartButtonPressed;
        loadButton.Pressed += OnLoadButtonPressed;
        settingButton.Pressed += OnSettingButtonPressed;
        quitButton.Pressed += OnQuitButtonPressed;
    }

	/// =====================================
	/// Button Functions
	/// =====================================
    private void OnStartButtonPressed()
    {
        
        // Load the game scene
        PackedScene gameScene = (PackedScene)GD.Load(GameScenePath);
        
        // Check if game scene exist
        if (gameScene != null)
        {
            // Load Scene Tree
            SceneTree tree = GetTree();
            
            // Instantiate game scene
            Node gameSceneInstance = gameScene.Instantiate();
            
            // Add game scene to root, free current scene, and set current scene to game scene
            tree.Root.AddChild(gameSceneInstance);
            tree.CurrentScene.QueueFree();
            tree.CurrentScene = gameSceneInstance;
        }
        else
        {
            GD.PrintErr("Failed to load the game scene at path: " + GameScenePath);
        }
    }

    private void OnLoadButtonPressed()
    {
        
    }

    private void OnSettingButtonPressed()
    {
        
    }

    private void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }
}