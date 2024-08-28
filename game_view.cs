using Godot;
using System;

public partial class game_view : Node2D
{
    private Node2D prologueNode;
    private Node2D mainGameplayNode;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Assume "Prologue" and "MainGameplay" are the names of the child nodes
        prologueNode = GetNode<Node2D>("Image Process");
        mainGameplayNode = GetNode<Node2D>("Input Process");

        // Initially, the prologue is visible, and the main gameplay is hidden
        prologueNode.Visible = true;
        mainGameplayNode.Visible = false;
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
        if(prologueNode.Visible == false)
        {
            prologueNode.Visible = true;
            mainGameplayNode.Visible = false;
            
            // Optionally, you can also stop the prologue processing if needed
            prologueNode.SetProcess(true);
            mainGameplayNode.SetProcess(false);
        }
        else
        {
            prologueNode.Visible = false;
            mainGameplayNode.Visible = true;
            
            // Optionally, you can also stop the prologue processing if needed
            prologueNode.SetProcess(false);
            mainGameplayNode.SetProcess(true);
        }


        // Add any additional logic needed to initialize the main gameplay
    }
}
