using Godot;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;

public partial class main_menu : Control
{
    // Linking to the game scene
    private const string GameScenePath = "res://code/game.tscn";
    private NetworkManager _networkManager;
    private Global global;
    private Window _joinServerWindow;
    private LineEdit _ipInput;
    private LineEdit _portInput;
    public override void _Ready()
    {
        global = (Global)GetNode("/root/Global");

        // Linking to Buttons
        Button startButton = GetNode<Button>("Button Menu/Start Game");
        Button loadButton = GetNode<Button>("Button Menu/Load Game");
        Button settingButton = GetNode<Button>("Button Menu/Settings");
        Button quitButton = GetNode<Button>("Button Menu/Quit");
        Button multiplayerButton = GetNode<Button>("Button Menu/Start Multiplayer Game");
        Button joinmultiplayerButton = GetNode<Button>("Button Menu/Join Multiplayer Game");

        // Get the NetworkManager node
        _networkManager = GetNode<NetworkManager>("NetworkManager");

        // Get the Join Server UI elements
        _joinServerWindow = GetNode<Window>("JoinServerWindow");
        _ipInput = _joinServerWindow.GetNode<LineEdit>("IPInput");
        _portInput = _joinServerWindow.GetNode<LineEdit>("PortInput");
        Button connectButton = _joinServerWindow.GetNode<Button>("ConnectButton");
        _joinServerWindow.Hide();

        // Buttons pressed
        startButton.Pressed += OnStartButtonPressed;
        loadButton.Pressed += OnLoadButtonPressed;
        settingButton.Pressed += OnSettingButtonPressed;
        quitButton.Pressed += OnQuitButtonPressed;
        multiplayerButton.Pressed += OnMultiplayerButtonPressed;
        joinmultiplayerButton.Pressed += OnJoinMultiplayerButtonPressed;
        connectButton.Pressed += OnConnectButtonPressed;

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
        global.multiplayer_game = true;

        // Start the server or connect to one
        _networkManager.StartServer(8080); // or _networkManager.JoinServer("127.0.0.1", 12345);

        // Load the game scene
        LoadGameScene();
    }

    private void OnJoinMultiplayerButtonPressed()
    {
        _joinServerWindow.Show();
        _joinServerWindow.PopupCentered();
    }
    private async void OnConnectButtonPressed()
    {
        // Get IP and Port from the input fields
        string hostIP = _ipInput.Text;
        int port = int.Parse(_portInput.Text);

        // Start as client
        _networkManager.JoinServer(hostIP, port);

        // Wait briefly to allow the connection attempt to process
        await ToSignal(GetTree().CreateTimer(1.0f), "timeout");

        // Check if the client is connected
        var multiplayerPeer = _networkManager.Multiplayer.MultiplayerPeer;
        if (multiplayerPeer != null && multiplayerPeer.GetConnectionStatus() == MultiplayerPeer.ConnectionStatus.Connected)
        {
            // Connection successful, load the game scene
            GD.Print("Connected to server...");
            LoadGameScene();

            // Hide the popup after connecting
            _joinServerWindow.Hide();
        }
        else
        {
            // Connection failed, show an error message
            GD.Print("Failed to connect to server.");
            // You may choose to keep the popup open here if you want the user to retry
            _joinServerWindow.Hide();
        }
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