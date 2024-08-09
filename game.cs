using Godot;
using System;

public partial class game : Node2D
{   
	private TextureRect fadeRect;
    private TextureRect fadeRect2;
	private TextureRect background;
    private SceneTree tree;

    public override async void _Ready()
    {
        //_fadeRect = GetNode<ColorRect>("FadeControl");
		fadeRect = GetNode<TextureRect>("FadeIn");// fade in to the background
		fadeRect2 = GetNode<TextureRect>("FadeOut");// fade out from background
        background = GetNode<TextureRect>("Background");
        tree = GetTree();

        if (fadeRect != null)
        {
            FadeIn(fadeRect);
        }

        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        background.Modulate = new Color(0, 0, 0, 0);
        
        if (fadeRect2 != null)
        {
            FadeOut(fadeRect2);
        }
        
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        //background.Modulate = new Color(1, 1, 1, 1);

    }

    private async void FadeIn(TextureRect fadeRect)
	{
		for (float i = 1.0f; i >= 0; i -= 0.01f)
		{
			fadeRect.Modulate = new Color(1, 1, 1, i);
			await ToSignal(GetTree().CreateTimer(0.03f), "timeout");
		}

		fadeRect.Modulate = new Color(0, 0, 0, 0);
	}

    private async void FadeOut(TextureRect fadeRect)
    {
        for (float i = 0; i <= 1.0f; i += 0.05f)
        {
            fadeRect.Modulate = new Color(1, 1, 1, i); // Adjust alpha from 0 to 1
            await ToSignal(tree.CreateTimer(0.1f), "timeout");
        }

		fadeRect.Modulate = new Color(1, 1, 1, 1);
    }
}
