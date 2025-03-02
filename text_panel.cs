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
    private TextureRect background;

    public override void _Ready()
    {
        // Linking to files and nodes
        global = (Global)GetNode("/root/Global");
        textLabel = GetNode<Label>("Texts");
        characterNameL = GetNode<Label>("CharacterNameL");
        characterNameR = GetNode<Label>("CharacterNameR");
        characterL = GetNode<TextureRect>("../CharacterL");
        characterR = GetNode<TextureRect>("../CharacterR");
        background = GetNode<TextureRect>("../Background");
        
        // Check if story exist
        if (global.storylines.Count >= 0)
        {
            updateTextPanel(global);
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
            GD.Print("Current line#: ", global.currentLine);
            GD.Print("Current line: ", global.storylines[global.currentLine]);
            GD.Print("Current highlight: ", global.highlightLR[global.currentLine]);

            //GD.Print("Current CharacterL: ", string.Join(", ", global.characterL[global.currentLine]));
            GD.Print("Current CharacterL:");
            foreach (var character in global.characterL[global.currentLine])
            {
                GD.Print(character);
            }

            //GD.Print("Current CharacterR: ", string.Join(", ", global.characterR[global.currentLine]));
            GD.Print("Current CharacterR:");
            foreach (var character in global.characterR[global.currentLine])
            {
                GD.Print(character);
            }
            
            //GD.Print("Current trigger events: ", string.Join(", ", global.triggerTagEvent[global.currentLine]));
            GD.Print("Current trigger events:");
            foreach (var triggerEvent in global.triggerTagEvent[global.currentLine])
            {
                GD.Print(triggerEvent);
            }

            updateTextPanel(global);
        }
        else
        {
            HidePanel();
        }
    }
    
    /// <summary>
    /// Updates the text panel based on the current storyline and character information.
    /// 
    /// This function takes a Global object as a parameter, which contains the current storyline, 
    /// character information, and other relevant data. It uses this data to update the text 
    /// label, character names, and other UI elements on the text panel.
    /// 
    /// The function also handles highlighting of characters based on the current storyline.
    /// </summary>
    // <param name= "global">The Global object containing the current storyline and character information.</param>
    private void updateTextPanel(Global global)
    {
        
        foreach (var triggerEvent in global.triggerTagEvent[global.currentLine])
        {
            string[] parts = triggerEvent.Split('_');
            switch(parts[0])
            {
                case "CharacterVisible":
                    if(parts[1] == "L")
                    {
                        characterL.Visible = true;
                    }
                    else if(parts[1] == "R")
                    {
                        characterR.Visible = true;
                    }
                    else if(parts[1] == "B")
                    {
                        characterL.Visible = true;
                        characterR.Visible = true;
                    }
                    break;
                case "CharacterInvisible":
                    if(parts[1] == "L")
                    {
                        characterL.Visible = false;
                    }
                    else if(parts[1] == "R")
                    {
                        characterR.Visible = false;
                    }
                    else if(parts[1] == "B")
                    {
                        characterL.Visible = false;
                        characterR.Visible = false;
                    }
                    break;
                case "Background":
                    background.Visible = false;
                    if(parts.Length > 1)
                    {
                        background = GetNode<TextureRect>("../"+parts[1]);
                    }
                    else
                    {
                        GD.PrintErr("No background found:"+parts[1]+"\nError at Line:"+global.currentLine);
                    }
                    background.Visible = true;
                    break;
            }   
        }
        
        if(global.highlightLR[global.currentLine] == "L") // Left Character
        {
            characterL.Modulate = new Color(1, 1, 1, 1);
            characterR.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
        }
        else if(global.highlightLR[global.currentLine] == "R") // Right Character
        {
            characterL.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
            characterR.Modulate = new Color(1, 1, 1, 1);
        }
        else if(global.highlightLR[global.currentLine] == "B") // Both
        {
            characterL.Modulate = new Color(1, 1, 1, 1);
            characterR.Modulate = new Color(1, 1, 1, 1);
        }
        else if(global.highlightLR[global.currentLine] != "")
        {
            characterL.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
            characterR.Modulate = new Color(0.501f, 0.501f, 0.501f, 1);
        }
        
        textLabel.Text = global.storylines[global.currentLine];
        characterNameL.Text = string.Join(", ", global.characterL[global.currentLine]);
        characterNameR.Text = string.Join(", ", global.characterR[global.currentLine]);

        ShowPanel();
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