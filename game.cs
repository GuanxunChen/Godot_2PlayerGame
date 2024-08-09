using Godot;
using System;

public partial class game : Node2D
{   
	private TextureRect _fadeRect;
    private TextureRect fadeRect2;
	//private TextureRect background;
    private SceneTree tree;

    public override async void _Ready()
    {
        //_fadeRect = GetNode<ColorRect>("FadeControl");
		_fadeRect = GetNode<TextureRect>("FadeIn");// fade in to the background
		fadeRect2 = GetNode<TextureRect>("FadeOut");// fade out from background
        //background = GetNode<TextureRect>("Background");
        tree = GetTree();

        if (_fadeRect != null)
        {
            FadeIn(_fadeRect);
        }
		GD.Print("fade in completed");
        await ToSignal(GetTree().CreateTimer(20.0f), "timeout");
		GD.Print("fade in 2 completed");
        //background.Modulate = new Color(0, 0, 0, 0);
        
        if (fadeRect2 != null)
        {
			fadeRect2.ZIndex = 1;
            FadeOut(fadeRect2);
			await ToSignal(GetTree().CreateTimer(20.0f), "timeout");
			FadeIn(fadeRect2);
        }
        
        //await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
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
		//fadeRect.ZIndex = 1;
		GD.Print("fade out");
        for (float i = 0; i <= 1.0f; i += 0.01f)
        {
            fadeRect.Modulate = new Color(1, 1, 1, i); // Adjust alpha from 0 to 1
            await ToSignal(tree.CreateTimer(0.03f), "timeout");
        }
		GD.Print("fade out done");
		//fadeRect.Modulate = new Color(1, 1, 1, 1);
    }
}
