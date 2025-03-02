using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private AnimationPlayer animationPlayer;
	public const float Speed = 500;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("Sprite2D/AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		//if (!IsOnFloor())
			//velocity.Y += gravity * (float)delta;

		// Handle Jump.
		//if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			//velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
			if(direction.X < 0)
			{
				animationPlayer.CurrentAnimation = "walk_left";
			}
			if(direction.X > 0)
			{
				animationPlayer.CurrentAnimation = "walk_right";
			}
			if(direction.Y < 0)
			{
				animationPlayer.CurrentAnimation = "walk_up";
			}
			if(direction.Y > 0)
			{
				animationPlayer.CurrentAnimation = "walk_down";
			}
		}
		else
		{
			// Decelerate both X and Y when no input is detected
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed * (float)delta);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed * (float)delta);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
