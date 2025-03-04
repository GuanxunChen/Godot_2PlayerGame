using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Skill
{
    public string Name { get; private set; }
    public bool IsUnlocked { get; private set; }
    public List<Skill> Dependencies { get; private set; }
    public List<Skill> DependentSkills { get; private set; }
    public int Cost { get; private set; }

    public Skill(string name, int cost)
    {
        Name = name;
        IsUnlocked = false;
        Dependencies = new List<Skill>();
        DependentSkills = new List<Skill>();
        Cost = cost;
    }

    public void AddDependency(Skill dependency)
    {
        Dependencies.Add(dependency);
        dependency.DependentSkills.Add(this);
    }

    public bool CanUnlock(int availableSkillPoints)
    {
        // Check if all dependencies are unlocked and there are enough skill points
        return Dependencies.All(d => d.IsUnlocked) && availableSkillPoints >= Cost;
    }

    public void Unlock()
    {
        IsUnlocked = true;
        GD.Print($"{Name} unlocked!");
    }

    public void Lock(ref int availableSkillPoints)
	{
		if (IsUnlocked)
		{
			availableSkillPoints += Cost; // Refund skill points
			IsUnlocked = false;
			GD.Print($"{Name} locked!");

			// Recursively lock dependent skills
			foreach (var dependentSkill in DependentSkills)
			{
				dependentSkill.Lock(ref availableSkillPoints);
			}
		}
	}

}
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
	public Boolean crossSlashPressed = false;
	public Boolean starburstStreamPressed = false;
	private Skill crossSlashSkill;
	private Skill starburstStreamSkill;

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
		
		crossSlashSkill = new Skill("CrossSlash", 1); // Cost: 1 skill point
		starburstStreamSkill = new Skill("StarburstStream", 2); // Cost: 2 skill points

		// Set dependencies
		starburstStreamSkill.AddDependency(crossSlashSkill);

		// Connect button signals
		crossSlash.Pressed += () => OnSkillButtonPressed(crossSlashSkill);
		starburstStream.Pressed += () => OnSkillButtonPressed(starburstStreamSkill);
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

	private void OnSkillButtonPressed(Skill skill)
	{
		if (!skill.IsUnlocked)
		{
			// Try to unlock the skill
			if (skill.CanUnlock(skillPoints))
			{
				skill.Unlock();
				skillPoints -= skill.Cost;
				points.Text = skillPoints.ToString();

				// Enable dependent skills if applicable
				if (skill == crossSlashSkill)
				{
					starburstStream.Disabled = false;
				}
			}
			else
			{
				GD.Print($"Cannot unlock {skill.Name}. Not enough skill points or dependencies not met.");
			}
		}
		else
		{
			// Lock the skill and all dependent skills
			LockSkillAndDependents(skill);
		}

		// Update UI
		UpdateSkillButtons();
	}
	private void LockSkillAndDependents(Skill skill)
	{
		// Lock the skill and refund its cost
		skill.Lock(ref skillPoints);
		points.Text = skillPoints.ToString();

		// Lock all dependent skills and refund their costs
		foreach (var dependentSkill in skill.DependentSkills)
		{
			if (dependentSkill.IsUnlocked)
			{
				LockSkillAndDependents(dependentSkill); // Recursively lock dependents
			}
		}

		// Disable dependent skill buttons if applicable
		if (skill == crossSlashSkill)
		{
			starburstStream.Disabled = true;
		}
	}
	private void UpdateSkillButtons()
	{
		// Update Cross Slash button
		if (crossSlashSkill.IsUnlocked)
		{
			// If Cross Slash is already unlocked, enable the button so it can be locked
			crossSlash.Disabled = false;
		}
		else
		{
			// If Cross Slash is not unlocked, disable the button if there aren't enough skill points
			crossSlash.Disabled = !crossSlashSkill.CanUnlock(skillPoints);
		}

		// Update Starburst Stream button
		if (starburstStreamSkill.IsUnlocked)
		{
			// If Starburst Stream is already unlocked, enable the button so it can be locked
			starburstStream.Disabled = false;
		}
		else
		{
			// If Starburst Stream is not unlocked, disable the button if Cross Slash is not unlocked or there aren't enough skill points
			starburstStream.Disabled = !crossSlashSkill.IsUnlocked || !starburstStreamSkill.CanUnlock(skillPoints);
		}
	}
}
