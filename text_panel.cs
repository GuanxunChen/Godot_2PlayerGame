using Godot;
using System;

public partial class text_panel : Panel
{
    private Global global;
    private Label textLabel;

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

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            ProceedToNextText(global);
        }
    }

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

    private void ShowPanel()
    {
        Visible = true;
    }

    private void HidePanel()
    {
        Visible = false;
    }
}
