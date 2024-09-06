using Godot;
using System;


public partial class NetworkManager : Node2D
{
    // Called when the node enters the scene tree for the first time.
    private ENetMultiplayerPeer _peer;

    public override void _Ready()
    {
        // Uncomment one of the following lines based on whether this instance is acting as a server or a client:

        // Start the server on port 12345
        // StartServer(12345);

        // Join the server at the specified IP and port
        // JoinServer("127.0.0.1", 12345);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void StartServer(int port)
    {
        _peer = new ENetMultiplayerPeer();
        Error result = _peer.CreateServer(port, 4); // Port 12345, max 4 clients
        if (result != Error.Ok)
        {
            GD.PrintErr("Failed to create server: " + result);
            return;
        }
        // Wait for the server to start
        while (_peer.GetConnectionStatus() == ENetMultiplayerPeer.ConnectionStatus.Disconnected)
        {
            _peer.Poll();
            OS.DelayMsec(10); // wait 10ms
        }
        Multiplayer.MultiplayerPeer = _peer;
        Multiplayer.PeerConnected += OnPeerConnected;
        Multiplayer.PeerDisconnected += OnPeerDisconnected;

        GD.Print("Server started on port " + port);
    }
    public void JoinServer(string address, int port)
    {
        _peer = new ENetMultiplayerPeer();
        Error result = _peer.CreateClient(address, port);
        if (result != Error.Ok)
        {
            GD.PrintErr("Failed to connect to server: " + result);
            return;
        }
        Multiplayer.MultiplayerPeer = _peer;
        Multiplayer.PeerConnected += OnPeerConnected;
        Multiplayer.PeerDisconnected += OnPeerDisconnected;

        GD.Print("Connected to server at " + address + ":" + port);
    }

    private void OnPeerConnected(long id)
    {
        GD.Print($"Player {id} connected");
    }

    private void OnPeerDisconnected(long id)
    {
        GD.Print($"Player {id} disconnected");
    }
}
