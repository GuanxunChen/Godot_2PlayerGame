using Godot;
using System;

public partial class main_menu : Control
{
	// Called when the node enters the scene tree for the first time.public override void _Ready()
	public override void _Ready()
    {
        /*Button startGameButton = GetNode<Button>("Start Game");
        startGameButton.Connect("pressed", this, nameof(OnStartGameButtonPressed));*/
    }

    // Method to handle the "Start Game" button press
    private void OnStartGameButtonPressed()
    {
        // Change the scene to the game scene
        GetTree().ChangeSceneToFile("res://game_scene.tscn");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Button startGameButton = GetNode<Button>("Start Game");
		startGameButton.Connect("pressed", new Callable(this, nameof(OnStartGameButtonPressed)));
	}
}
