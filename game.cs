using Godot;
using System;

public partial class game : Node2D
{   
    //private ColorRect _fadeRect;
	private TextureRect _fadeRect;
    private TextureRect _fadeRect2;
    private SceneTree _tree;

    public override async void _Ready()
    {
        //_fadeRect = GetNode<ColorRect>("FadeControl");
		_fadeRect = GetNode<TextureRect>("FadeIn");// fade in to the background
		_fadeRect2 = GetNode<TextureRect>("FadeOut");// fade out from background
        _tree = GetTree();

        if (_fadeRect != null)
        {
            FadeIn(_fadeRect);
        }

        if (_fadeRect2 != null)
        {
            FadeOut(_fadeRect2);
        }

    }

    private async void FadeIn(TextureRect _fadeRect)
	{
		for (float i = 1.0f; i >= 0; i -= 0.01f)
		{
			_fadeRect.Modulate = new Color(1, 1, 1, i);
			await ToSignal(GetTree().CreateTimer(0.03f), "timeout");
		}

		_fadeRect.Modulate = new Color(0, 0, 0, 0);
	}

    private async void FadeOut(TextureRect _fadeRect)
    {
        for (float i = 0; i <= 1.0f; i += 0.05f)
        {
            _fadeRect.Modulate = new Color(1, 1, 1, i); // Adjust alpha from 0 to 1
            await ToSignal(_tree.CreateTimer(0.1f), "timeout");
        }

		_fadeRect.Modulate = new Color(1, 1, 1, 1);
    }
}
