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

        textLabel.Text = global.storylines[global.currentLine];

        ShowPanel();
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
            GetNode<Label>("Texts").Text = global.storylines[global.currentLine];
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
