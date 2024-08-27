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

    public override async void _Ready()
    {
        // Load Scene Tree
        tree = GetTree();

        // Linking to nodes
        global = (Global)GetNode("/root/Global");


		fadeRect = GetNode<TextureRect>("FadeIn");
		fadeRect2 = GetNode<TextureRect>("FadeOut");
        zoomRect = GetNode<TextureRect>("ZoomIn");

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
            //zoomRect.Position = (GetViewportRect().Size - zoomRect.Size) / 2;
            ZoomIn(zoomRect, 0.01f, 0.03f);
        }
        await ToSignal(GetTree().CreateTimer(5.0f), "timeout");
        zoomRect.ZIndex = 0;
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

    private async void ZoomIn(TextureRect zoomRect, float speed, float timer)
    {
        // Set to the top
        zoomRect.ZIndex = 1;
        zoomRect.PivotOffset = zoomRect.Size / 2;
        
        // Adjust size from small to big
        for (float i = 0; i <= 1.0f; i += speed)
        {
            zoomRect.Scale = new Vector2(1 + i, 1 + i);
            //zoomRect.Position = (GetViewportRect().Size - zoomRect.Size) / 2;
            await ToSignal(tree.CreateTimer(timer), "timeout");
        }
    }
}