using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class main_menu : Control
{
    // Linking to the game scene
    private const string GameScenePath = "res://game.tscn";
    private NetworkManager _networkManager;

    public override void _Ready()
    {
		// Linking to Buttons
        Button startButton = GetNode<Button>("Button Menu/Start Game");
        Button loadButton = GetNode<Button>("Button Menu/Load Game");
        Button settingButton = GetNode<Button>("Button Menu/Settings");
        Button quitButton = GetNode<Button>("Button Menu/Quit");
        Button multiplayerButton = GetNode<Button>("Button Menu/Start Multiplayer Game");
        Button joinmultiplayerButton = GetNode<Button>("Button Menu/Join Multiplayer Game");
        
        // Get the NetworkManager node
        _networkManager = GetNode<NetworkManager>("NetworkManager");
		// Buttons pressed
        startButton.Pressed += OnStartButtonPressed;
        loadButton.Pressed += OnLoadButtonPressed;
        settingButton.Pressed += OnSettingButtonPressed;
        quitButton.Pressed += OnQuitButtonPressed;
        multiplayerButton.Pressed += OnMultiplayerButtonPressed;
        joinmultiplayerButton.Pressed += OnJoinMultiplayerButtonPressed;


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
    private void OnMultiplayerButtonPressed()
    {
        // Start the server or connect to one
        _networkManager.StartServer(12345); // or _networkManager.JoinServer("127.0.0.1", 12345);

        // Load the game scene
        LoadGameScene();
    }

    private void OnJoinMultiplayerButtonPressed()
    {
            // Assume this is a client connecting to an existing host
        string hostIP = "192.168.1.169"; // Replace with actual IP address
        int port = 12345; // Replace with the port used by the host

        // Start as client
        _networkManager.JoinServer(hostIP, port);
        // Load the game scene
        LoadGameScene();
    }
    private void LoadGameScene()
    {
        // Load the game scene
        PackedScene gameScene = (PackedScene)GD.Load(GameScenePath);

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
}