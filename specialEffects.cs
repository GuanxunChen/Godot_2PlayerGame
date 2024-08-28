using Godot;
using System;

public partial class specialEffects : Node2D
{   
    private Global global;
    private SceneTree tree;
    private TextureRect characterPortraitL;
    private TextureRect characterPortraitR;
	private TextureRect fadeRect;
    private TextureRect fadeRect2;
    private TextureRect zoomRect;
    private TextureRect zoomRect2;

    public override async void _Ready()
    {
        // Load Scene Tree
        tree = GetTree();

        // Linking to nodes
        global = (Global)GetNode("/root/Global");


		fadeRect = GetNode<TextureRect>("FadeIn");
		fadeRect2 = GetNode<TextureRect>("FadeOut");
        zoomRect = GetNode<TextureRect>("ZoomIn");
        zoomRect2 = GetNode<TextureRect>("ZoomOut");
/*
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

        // Zoom in
        if (zoomRect != null)
        {
            // Center the TextureRect in the viewport
            zoomRect.Position = (GetViewportRect().Size - zoomRect.Size) / 2;

            ZoomIn(zoomRect, 0.2f, 0.02f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        zoomRect.ZIndex = 0;
*/
        
        // Zoom out
        if (zoomRect2 != null)
        {
            // Center the TextureRect in the viewport
            zoomRect2.Position = (GetViewportRect().Size - zoomRect.Size) / 2;

            ZoomOut(zoomRect2, 1f, 0.01f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        zoomRect2.ZIndex = 0;
    }
    
    /// =====================================
	/// Portrait Functions
	/// =====================================

    /// =====================================
	/// Image Effect Functions
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

    private async void ZoomIn(TextureRect zoomRect, float ratio, float speed, float timer)
    {
        zoomRect.Scale = new Vector2(ratio, ratio);

        // Set to the top
        zoomRect.ZIndex = 1;
        zoomRect.PivotOffset = zoomRect.Size / 2;

        // Adjust size from small to big
        while (ratio <= 1)
        {
            ratio += speed;
            zoomRect.Scale = new Vector2(ratio, ratio);
            zoomRect.Position = (GetViewportRect().Size - zoomRect.Size) / 2;
            await ToSignal(tree.CreateTimer(timer), "timeout");
        }
    }
    
    private async void ZoomOut(TextureRect zoomRect, float ratio, float speed, float timer)
    {
        zoomRect.Scale = new Vector2(ratio, ratio);

        // Set to the top
        zoomRect.ZIndex = 1;
        zoomRect.PivotOffset = zoomRect.Size / 2;

        // Adjust size from small to big
        while (ratio >= 0)
        {
            zoomRect.Scale = new Vector2(ratio, ratio);
            ratio -= speed;
            zoomRect.Position = (GetViewportRect().Size - zoomRect.Size) / 2;
            await ToSignal(tree.CreateTimer(timer), "timeout");
        }

        if(ratio <= 0)
        {
		    zoomRect.Modulate = new Color(0, 0, 0, 0);
        }
    }
}