using Godot;
using System;

public partial class text_panel : Panel
{
    private Global global;
    private Label textLabel;
    private Label characterNameL;
    private Label characterNameR;

    public override void _Ready()
    {
        // Linking to files and nodes
        global = (Global)GetNode("/root/Global");
        textLabel = GetNode<Label>("Texts");
        characterNameL = GetNode<Label>("CharacterNameL");
        characterNameR = GetNode<Label>("CharacterNameR");
        
        // Check if story exist
        if (global.storylines.Count > 0)
        {
            // Set the text of the label to the current storyline
            textLabel.Text = global.storylines[global.currentLine];

            // Set character names label to current characters
            characterNameL.Text = global.characterL[global.currentLine];
            characterNameR.Text = global.characterR[global.currentLine];

            ShowPanel();
        }
        else
        {
            GD.PrintErr("No storylines found.");
            HidePanel();
        }
    }

    /// =====================================
	/// Event Listener Functions
	/// =====================================
    public override void _Input(InputEvent @event) // Mouse Click Function
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            ProceedToNextLine(global);
        }
    }

    /// =====================================
	/// StoryLine Function
	/// =====================================
    private void ProceedToNextLine(Global global)
    {
        global.currentLine++;

        // Steping through story
        if (global.currentLine < global.storylines.Count)
        {
            textLabel.Text = global.storylines[global.currentLine];
            characterNameL.Text = global.characterL[global.currentLine];
            characterNameR.Text = global.characterR[global.currentLine];
        }
        else
        {
            HidePanel();
        }
    }

    private void JumpToStoryLine(Global global, int line)
    {
        // Steping through story
        if (line < global.storylines.Count)
        {
            textLabel.Text = global.storylines[line];
            characterNameL.Text = global.characterL[global.currentLine];
            characterNameR.Text = global.characterR[global.currentLine];
        }
        else
        {
            HidePanel();
        }
    }

    /// =====================================
	/// Panel Visibility Functions
	/// =====================================
    private void ShowPanel()
    {
        Visible = true;
    }

    private void HidePanel()
    {
        Visible = false;
    }
}
