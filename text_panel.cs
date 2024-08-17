using Godot;
using System;

public partial class text_panel : Panel
{
    private Global global;
    private Label textLabel;

        /// <summary>
        /// Initializes the text panel by retrieving the Global node and the Texts label.
        /// If there are any storylines in the Global node, it sets the text of the Texts label to the current storyline and shows the panel.
        /// Otherwise, it prints an error message and hides the panel.
        /// </summary>
    public override void _Ready()
    {
        global = (Global)GetNode("/root/Global");
        textLabel = GetNode<Label>("Texts");

        if (global.storylines.Count > 0)
        {
            textLabel.Text = global.storylines[global.currentLine];
            ShowPanel();
        }
        else
        {
            GD.PrintErr("No storylines found.");
            HidePanel();
        }
    }

    /// <summary>
    /// Handles input events. If a mouse button is pressed, it proceeds to the next text in the story.
    /// </summary>
    /// <param name="@event">The input event to be handled.</param>
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            ProceedToNextText(global);
        }
    }

    /// <summary>
    /// Proceeds to the next text in the story by incrementing the current line index.
    /// If the current line index exceeds the total number of storylines, it hides the panel.
    /// </summary>
    /// <param name="global">The Global object containing the storylines and current line index.</param>
    private void ProceedToNextText(Global global)
    {
        global.currentLine++;

        if (global.currentLine < global.storylines.Count)
        {
            textLabel.Text = global.storylines[global.currentLine];
        }
        else
        {
            HidePanel();
        }
    }

    /// <summary>
    /// Shows the panel by setting its Visible property to true.
    /// </summary>
    private void ShowPanel()
    {
        Visible = true;
    }

    /// <summary>
    /// Hides the panel by setting its Visible property to false.
    /// </summary>
    private void HidePanel()
    {
        Visible = false;
    }
}
