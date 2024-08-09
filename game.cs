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
        background = GetNode<TextureRect>("CoverOfFade");
        tree = GetTree();

        if (fadeRect != null)
        {
            FadeIn(fadeRect, 0.01f, 0.01f);
        }

        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        background.Modulate = new Color(1, 1, 1, 0);
        
        if (fadeRect2 != null)
        {
            FadeOut(fadeRect2, 0.01f, 0.01f);
        }
        
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");

        if (background != null)
        {
            FadeOut(background, 0.01f, 0.01f);
        }

        //background.Modulate = new Color(1, 1, 1, 1);

    }

    private async void FadeIn(TextureRect fadeRect, float speed, float timer)
	{
		for (float i = 1.0f; i >= 0; i -= speed)
		{
			fadeRect.Modulate = new Color(1, 1, 1, i);
			await ToSignal(GetTree().CreateTimer(timer), "timeout");
		}

		fadeRect.Modulate = new Color(0, 0, 0, 0);
	}

    private async void FadeOut(TextureRect fadeRect, float speed, float timer)
    {
        for (float i = 0; i <= 1.0f; i += speed)
        {
            fadeRect.Modulate = new Color(1, 1, 1, i); // Adjust alpha from 0 to 1
            await ToSignal(tree.CreateTimer(timer), "timeout");
        }

		fadeRect.Modulate = new Color(1, 1, 1, 1);
    }
}
