using Godot;
using System;

public partial class game : Node2D
{
    private ColorRect _fadeRect;
    private SceneTree _tree;

    public override void _Ready()
    {
        _fadeRect = GetNode<ColorRect>("FadeControl");
        _tree = GetTree();

        if (_fadeRect != null)
        {
            GD.Print("FadeControl found. Starting Fade In");
            FadeIn();
        }
        else
        {
            GD.PrintErr("FadeControl not found!");
        }
    }

    private async void FadeIn()
	{
		GD.Print("Fade In started");

		for (float i = 1.0f; i >= 0; i -= 0.01f)
		{
			Color currentColor = new Color(0, 0, 0, i);
			_fadeRect.Modulate = currentColor;
			GD.Print("Current Alpha: " + i + " | Modulate: " + _fadeRect.Modulate);
			await ToSignal(GetTree().CreateTimer(0.03f), "timeout");
		}

		_fadeRect.Modulate = new Color(0, 0, 0, 0); // Ensure the final color is fully transparent
		GD.Print("Fade In complete");
	}

}
