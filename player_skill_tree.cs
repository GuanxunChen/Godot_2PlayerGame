using Godot;
using System;

public partial class player_skill_tree : Node2D
{
	private Camera2D camera;
	private TextureButton attackButton;
	private TextureButton passiveButton;
	private TextureButton petButton;
	private TextureButton explorationButton;
	private Button backAttackButton;
	private TextureButton playerButton;
	private Button backPassiveButton;
	private Button backPetButton;
	private Button backExplorationButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get the Camera2D node from the scene tree and assign it to the 'camera' variable.
		camera = GetNode<Camera2D>("Panel/Camera2D");


		attackButton = GetNode<TextureButton>("Panel/Attack");
		passiveButton = GetNode<TextureButton>("Panel/Passive");
		petButton = GetNode<TextureButton>("Panel/Pet");
		explorationButton = GetNode<TextureButton>("Panel/Exploration");

		backAttackButton = GetNode<Button>("Panel/Attack/Button");
		backPassiveButton = GetNode<Button>("Panel/Passive/Button");
		backPetButton = GetNode<Button>("Panel/Pet/Button");
		backExplorationButton = GetNode<Button>("Panel/Exploration/Button");

		playerButton = GetNode<TextureButton>("Panel/TextureButton");

		backAttackButton.Visible = false;
		backPassiveButton.Visible = false;
		backPetButton.Visible = false;
		backExplorationButton.Visible = false;


		// Connect the 'pressed' signal of the 'attackButton' node to the 'attacklabelclicked' method.
		attackButton.Pressed += attackButtonClicked;
		backAttackButton.Pressed += backButtonClicked;

		passiveButton.Pressed += passiveButtonClicked;
		backPassiveButton.Pressed += backButtonClicked;

		petButton.Pressed += petButtonClicked;
		backPetButton.Pressed += backButtonClicked;

		explorationButton.Pressed += explorationButtonClicked;
		backExplorationButton.Pressed += backButtonClicked;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void attackButtonClicked()
	{
		camera.Position = new Vector2(960/2, 540/2);
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backAttackButton.Visible = true;
	}

	public void backButtonClicked()
	{
		camera.Position = new Vector2(960, 540);
		camera.Zoom = new Vector2(1.0f, 1.0f);
		playerButton.Visible = true;
		backAttackButton.Visible = false;
		backPassiveButton.Visible = false;
		backPetButton.Visible = false;
		backExplorationButton.Visible = false;
	}

	private void petButtonClicked()
	{
		camera.Position = new Vector2(1440, 540/2);
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backPetButton.Visible = true;
	}

	public void passiveButtonClicked()
	{
		camera.Position = new Vector2(960/2, 540 + (540/2));
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backPassiveButton.Visible = true;
	}
	public void explorationButtonClicked()
	{
		camera.Position = new Vector2(960 + (960/2), 540 + (540/2));
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backExplorationButton.Visible = true;
	}
}
