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
	private Control attackControl;
	private Control passiveControl;
	private Control petControl;
	private Control explorationControl;
	private Label attackLabel;
	private Line2D swordLine;
	private Button crossSlash;
	private Button starburstStream;
	public int skillPoints = 3;
	private Label skillPointsLabel;
	private Label points;

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
		attackLabel = GetNode<Label>("Panel/Attack/Label");

		attackControl = GetNode<Control>("Panel/Attack/AttackControl");
		passiveControl = GetNode<Control>("Panel/Passive/PassiveControl");
		petControl = GetNode<Control>("Panel/Pet/PetControl");
		explorationControl = GetNode<Control>("Panel/Exploration/ExplorationControl");

		swordLine = GetNode<Line2D>("Panel/Attack/SwordLine");

		crossSlash = GetNode<Button>("Panel/Attack/AttackControl/Sword/Cross Slash");
		starburstStream = GetNode<Button>("Panel/Attack/AttackControl/Sword/Starburst Stream");

		skillPointsLabel = GetNode<Label>("Panel/SkillPoints");
		points = GetNode<Label>("Panel/SkillPoints/points");

		backAttackButton.Visible = false;
		backPassiveButton.Visible = false;
		backPetButton.Visible = false;
		backExplorationButton.Visible = false;
		attackControl.Visible = false;
		passiveControl.Visible = false;
		petControl.Visible = false;
		explorationControl.Visible = false;

		starburstStream.Disabled = true;

		swordLine.Visible = false;
		points.Text = skillPoints.ToString();

		skillPointsLabel.Visible = false;


		// Connect the 'pressed' signal of the 'attackButton' node to the 'attacklabelclicked' method.
		attackButton.Pressed += attackButtonClicked;
		backAttackButton.Pressed += backButtonClicked;

		passiveButton.Pressed += passiveButtonClicked;
		backPassiveButton.Pressed += backButtonClicked;

		petButton.Pressed += petButtonClicked;
		backPetButton.Pressed += backButtonClicked;

		explorationButton.Pressed += explorationButtonClicked;
		backExplorationButton.Pressed += backButtonClicked;
		crossSlash.Pressed += crossSlashClicked;
		starburstStream.Pressed += starburstStreamClicked;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		/*if (skillPoints == 0)
		{
			crossSlash.ToggleMode = false;
			GD.Print("Not enough skill points");
		}*/
	}
	// Attack
	public void attackButtonClicked()
	{
		camera.Position = new Vector2(960/2, 540/2);
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backAttackButton.Visible = true;
		attackControl.Visible = true;
		attackLabel.Visible = false;
		attackButton.Disabled = true;
		swordLine.Visible = true;
		skillPointsLabel.Visible = true;
		skillPointsLabel.Position = new Vector2(832, 0);
	}
	public void crossSlashClicked()
	{
		if(skillPoints < 1)
		{
			crossSlash.ToggleMode = false;
			GD.Print("Not enough skill points");
			return;
		}
		starburstStream.Disabled = false;
		skillPoints -= 1;
		points.Text = skillPoints.ToString();
	}
	public void starburstStreamClicked()
	{
		if(skillPoints < 2)
		{
			starburstStream.ToggleMode = false;
			GD.Print("Not enough skill points");
			return;
		}
		skillPoints -= 2;
		points.Text = skillPoints.ToString();
	}
	
	// Pet
	private void petButtonClicked()
	{
		camera.Position = new Vector2(1440, 540/2);
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backPetButton.Visible = true;
		petButton.Disabled = true;
		petControl.Visible = true;
		skillPointsLabel.Visible = true;
		skillPointsLabel.Position = new Vector2(1792, 0);
	}
	// Passive
	public void passiveButtonClicked()
	{
		camera.Position = new Vector2(960/2, 540 + (540/2));
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backPassiveButton.Visible = true;
		passiveButton.Disabled = true;
		passiveControl.Visible = true;
		skillPointsLabel.Visible = true;
		skillPointsLabel.Position = new Vector2(832, 540);
	}
	// Exploration
	public void explorationButtonClicked()
	{
		camera.Position = new Vector2(960 + (960/2), 540 + (540/2));
		camera.Zoom = new Vector2(2.0f, 2.0f);
		playerButton.Visible = false;
		backExplorationButton.Visible = true;
		explorationButton.Disabled = true;
		explorationControl.Visible = true;
		skillPointsLabel.Visible = true;
		skillPointsLabel.Position = new Vector2(1792, 540);
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
		attackButton.Visible = true;
		attackControl.Visible = false;
		passiveControl.Visible = false;
		petControl.Visible = false;
		explorationControl.Visible = false;
		attackLabel.Visible = true;
		attackButton.Disabled = false;
		swordLine.Visible = false;
		passiveButton.Disabled = false;
		petButton.Disabled = false;
		explorationButton.Disabled = false;
		skillPointsLabel.Visible = false;
	}
}
