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
            GD.Print("FadeControl found. Starting Fade In");
            FadeIn();
        }
        else
        {
            GD.PrintErr("FadeControl not found!");
        }
        
        await ToSignal(GetTree().CreateTimer(100.0f),"");

        if (_fadeRect2 != null)
        {            
            FadeOut();
        }

    }

    private async void FadeIn()
	{
		//GD.Print("Fade In started");

		for (float i = 1.0f; i >= 0; i -= 0.01f)
		{
			Color currentColor = new Color(1, 1, 1, i);
			_fadeRect.Modulate = currentColor;
			//GD.Print("Current Alpha: " + i + " | Modulate: " + _fadeRect.Modulate);
			await ToSignal(GetTree().CreateTimer(0.03f), "timeout");
		}

		_fadeRect.Modulate = new Color(0, 0, 0, 0); // Ensure the final color is fully transparent
		//GD.Print("Fade In complete");
	}

    private async void FadeOut()
    {
        for (float i = 0; i <= 1.0f; i += 0.05f)
        {
            _fadeRect.Modulate = new Color(1, 1, 1, i); // Adjust alpha from 0 to 1
            await ToSignal(_tree.CreateTimer(0.05f), "timeout");
        }
    }

}
