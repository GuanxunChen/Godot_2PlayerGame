using Godot;
using System;

public partial class text_panel : Panel
{
    private Global global;
    private Label textLabel;
    private Label characterNameL;
    private Label characterNameR;
    private TextureRect characterL;
    private TextureRect characterR;

    public override void _Ready()
    {
        // Linking to files and nodes
        global = (Global)GetNode("/root/Global");
        textLabel = GetNode<Label>("Texts");
        characterNameL = GetNode<Label>("CharacterNameL");
        characterNameR = GetNode<Label>("CharacterNameR");
        characterL = GetNode<TextureRect>("../CharacterL");
        characterR = GetNode<TextureRect>("../CharacterR");
        
        // Check if story exist
        if (global.storylines.Count >= 0)
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
            updateTextPanel(global);
        }
        else
        {
            HidePanel();
        }
        
        GD.Print("Current line#: ", global.currentLine);
        GD.Print("Current highlight: ", global.highlightLR[global.currentLine]);
        GD.Print("Current CharacterL: ", global.characterL[global.currentLine]);
        GD.Print("Current CharacterR: ", global.characterR[global.currentLine]);
    }

    private void updateTextPanel(Global global)
    {
        if(global.highlightLR[global.currentLine] == "L")
        {
            characterL.Modulate = new Color(1, 1, 1, 1);
            characterR.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
        }
        else if(global.highlightLR[global.currentLine] == "R")
        {
            characterL.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
            characterR.Modulate = new Color(1, 1, 1, 1);
        }
        else if(global.highlightLR[global.currentLine] == "B")
        {
            characterL.Modulate = new Color(1, 1, 1, 1);
            characterR.Modulate = new Color(1, 1, 1, 1);
        }else
        {
            characterL.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
            characterR.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
        }
        
        textLabel.Text = global.storylines[global.currentLine];
        characterNameL.Text = global.characterL[global.currentLine];
        characterNameR.Text = global.characterR[global.currentLine];
    }

    private void JumpToStoryLine(Global global, int line)
    {
        // Steping through story
        if (line < global.storylines.Count)
        {
            global.currentLine = line;
            updateTextPanel(global);
        }
        else
        {
            HidePanel();
        }
    }
    private void JumpToLineById(string id)
    {
        if (global.storyIdIndexMap.ContainsKey(id))
        {
            global.currentLine = global.storyIdIndexMap[id];
            updateTextPanel(global);
        }
        else
        {
            GD.PrintErr($"Line with id {id} not found.");
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
