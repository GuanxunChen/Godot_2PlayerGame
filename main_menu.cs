using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class main_menu : Control
{
    // Path to the game scene
    private const string GameScenePath = "res://game.tscn";

    /// <summary>
    /// Initializes the main menu by retrieving the start, load, settings, and quit buttons.
    /// It then sets up event handlers for each button's pressed event.
    /// </summary>
    public override void _Ready()
    {
		// Get Buttons
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