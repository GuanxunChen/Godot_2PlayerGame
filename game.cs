using Godot;
using System;

public partial class game : Node2D
{   
	private TextureRect fadeRect;
    private TextureRect fadeRect2;
    private SceneTree tree;

    public override async void _Ready()
    {
		fadeRect = GetNode<TextureRect>("FadeIn");// fade in to the background
		fadeRect2 = GetNode<TextureRect>("FadeOut");// fade out from background
        tree = GetTree();

        if (fadeRect != null)
        {
            FadeIn(fadeRect, 0.01f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        fadeRect.ZIndex = 0;
        
        if (fadeRect2 != null)
        {
            FadeOut(fadeRect2, 0.01f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        fadeRect2.ZIndex = 0;
    }

    private async void FadeIn(TextureRect fadeRect, float speed, float timer)
	{
		fadeRect.ZIndex = 1;
		for (float i = 1.0f; i >= 0; i -= speed)
		{
			fadeRect.Modulate = new Color(1, 1, 1, i);
			await ToSignal(GetTree().CreateTimer(timer), "timeout");
		}

		fadeRect.Modulate = new Color(0, 0, 0, 0);
	}

    private async void FadeOut(TextureRect fadeRect, float speed, float timer)
    {
		fadeRect.ZIndex = 1;
        for (float i = 0; i <= 1.0f; i += speed)
        {
            fadeRect.Modulate = new Color(1, 1, 1, i); // Adjust alpha from 0 to 1
            await ToSignal(tree.CreateTimer(timer), "timeout");
        }
		fadeRect.Modulate = new Color(1, 1, 1, 1);
    }
}
