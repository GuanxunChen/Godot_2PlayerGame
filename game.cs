using Godot;
using System;

public partial class game : Node2D
{   
    private SceneTree tree;
	private TextureRect fadeRect;
    private TextureRect fadeRect2;

    public override async void _Ready()
    {
        // Load Scene Tree
        tree = GetTree();

        // Linking to nodes
		fadeRect = GetNode<TextureRect>("FadeIn");
		fadeRect2 = GetNode<TextureRect>("FadeOut");

        // Fade in
        if (fadeRect != null)
        {
            FadeIn(fadeRect, 0.01f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        fadeRect.ZIndex = 0;
        
        // Fade out
        if (fadeRect2 != null)
        {
            FadeOut(fadeRect2, 0.01f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        fadeRect2.ZIndex = 0;
    }

    /// =====================================
	/// Image Fading Functions
	/// =====================================
    private async void FadeIn(TextureRect fadeRect, float speed, float timer)
	{
        // Set to the top
		fadeRect.ZIndex = 1;

        // Adjust visibility from 1 to 0
		for (float i = 1.0f; i >= 0; i -= speed)
		{
			fadeRect.Modulate = new Color(1, 1, 1, i);
			await ToSignal(GetTree().CreateTimer(timer), "timeout");
		}

		fadeRect.Modulate = new Color(0, 0, 0, 0);
	}

    private async void FadeOut(TextureRect fadeRect, float speed, float timer)
    {
		// Set to the top
        fadeRect.ZIndex = 1;

        // Adjust visibility from 0 to 1
        for (float i = 0; i <= 1.0f; i += speed)
        {
            fadeRect.Modulate = new Color(1, 1, 1, i); 
            await ToSignal(tree.CreateTimer(timer), "timeout");
        }

		fadeRect.Modulate = new Color(1, 1, 1, 1);
    }
}