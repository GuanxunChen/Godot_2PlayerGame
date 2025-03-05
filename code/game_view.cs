using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class game_view : Node2D
{
    private Node2D imageProcess;
    private Node2D inputProcess;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Assume "Prologue" and "MainGameplay" are the names of the child nodes
        imageProcess = GetNode<Node2D>("Image Process");
        inputProcess = GetNode<Node2D>("Input Process");

        // Initially, the prologue is visible, and the main gameplay is hidden
        imageProcess.Visible = true;
        inputProcess.Visible = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            // Logic to switch from prologue to main gameplay
            SwitchToMainGameplay();
        }
    }

    private void SwitchToMainGameplay()
    {
        // Hide the prologue and show the main gameplay
        if(imageProcess.Visible == false)
        {
            imageProcess.Visible = true;
            inputProcess.Visible = false;

            // Optionally, you can also stop the prologue processing if needed
            imageProcess.SetProcess(true);
            inputProcess.SetProcess(false);
        }
        else
        {
            imageProcess.Visible = false;
            inputProcess.Visible = true;
            
            // Optionally, you can also stop the prologue processing if needed
            imageProcess.SetProcess(false);
            inputProcess.SetProcess(true);
        }


        // Add any additional logic needed to initialize the main gameplay
    }
}