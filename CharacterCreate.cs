using Godot;
using System;

public partial class CharacterCreate : Node2D
{   
    // Variables for customization
    private int currentHairstyle = 0;
    private Texture2D[] hairstyleImages = {
        GD.Load<Texture2D>("res://art/temp,testing/characterCreation/hairstyles/hair1.jpg"),
    	GD.Load<Texture2D>("res://art/temp,testing/characterCreation/hairstyles/hair2.jpg"),
    	GD.Load<Texture2D>("res://art/temp,testing/characterCreation/hairstyles/hair3.jpg")
    };
    /*private string[] hairstyleTextures = {
        "res://hair1.jpg",
        "res://hair2.jpg",
        "res://hair3.jpg"
    };*/

    // Nodes for customization
    //private Sprite2D hairSprite;
    private TextureRect hairstylePreview;
    private Sprite2D hairSprite;
	private Button LeftArrow;
	private Button RightArrow;
    private HSlider redSlider, greenSlider, blueSlider;

    public override void _Ready()
    {
        // Get node references
        //hairSprite = GetNode<Sprite2D>("CharacterDisplay/Hair");
        hairstylePreview = GetNode<TextureRect>("Control/VBoxContainer/HBoxContainer/TextureRect");
        hairSprite = GetNode<Sprite2D>("CharacterDisplay/Hair");

        

		LeftArrow = GetNode<Button>("Control/VBoxContainer/HBoxContainer/Left Arrow");
		RightArrow = GetNode<Button>("Control/VBoxContainer/HBoxContainer/Right Arrow");
		LeftArrow.Pressed += OnLeftButtonPressed;
		RightArrow.Pressed += OnRightButtonPressed;

		UpdateCharacter();

        redSlider = GetNode<HSlider>("Control/VBoxContainer/redSlider");
        greenSlider = GetNode<HSlider>("Control/VBoxContainer/greenSlider");
        blueSlider = GetNode<HSlider>("Control/VBoxContainer/blueSlider");

        redSlider.ValueChanged += OnSliderValueChanged;
        greenSlider.ValueChanged += OnSliderValueChanged;
        blueSlider.ValueChanged += OnSliderValueChanged;
    }

    // Change hairstyle based on direction
    public void ChangeHairstyle(int direction)
    {
        currentHairstyle = (currentHairstyle + direction) % hairstyleImages.Length;
        if (currentHairstyle < 0)
        {
            currentHairstyle = hairstyleImages.Length - 1;
        }
        UpdateCharacter();
    }

    // Update character appearance and preview
    private void UpdateCharacter()
    {
        // Update character's hair texture
        //hairSprite.Texture = GD.Load<Texture2D>(hairstyleTextures[currentHairstyle]);
        // Update preview image
        hairstylePreview.Texture = hairstyleImages[currentHairstyle];
        hairSprite.Texture = hairstyleImages[currentHairstyle];
    }

    // Button signals
    private void OnLeftButtonPressed()
    {
        ChangeHairstyle(-1);
    }

    private void OnRightButtonPressed()
    {
        ChangeHairstyle(1);
    }

    private void OnSliderValueChanged(double value)
    {
        UpdateHairColor();
    }

    private void UpdateHairColor()
    {
        // Get RGB values from sliders
        float red = (float)redSlider.Value / 255f;
        float green = (float)greenSlider.Value / 255f;
        float blue = (float)blueSlider.Value / 255f;

        // Update the modulate color of the Sprite2D node
        hairSprite.Modulate = new Color(red, green, blue);

    }
}


