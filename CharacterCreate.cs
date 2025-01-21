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
    private int currentOutfit = 0;
    private Texture2D[] outfitImages = {
        GD.Load<Texture2D>("res://art/temp,testing/characterCreation/outfits/outfit1.png"),
    	GD.Load<Texture2D>("res://art/temp,testing/characterCreation/outfits/outfit2.png"),
    	GD.Load<Texture2D>("res://art/temp,testing/characterCreation/outfits/outfit3.png"),
    	GD.Load<Texture2D>("res://art/temp,testing/characterCreation/outfits/outfit4.png")
    };

    // Nodes for customization
    //private Sprite2D hairSprite;
    private TextureRect hairstylePreview;
    private Sprite2D hairSprite;
    private TextureRect outfitPreview;
    private Sprite2D outfitSprite;
	private Button HairLeftArrow;
	private Button HairRightArrow;
    private Button OutfitLeftArrow;
    private Button OutfitRightArrow;
    private HSlider redSlider, greenSlider, blueSlider;

    public override void _Ready()
    {
        // Get node references
        //hairSprite = GetNode<Sprite2D>("CharacterDisplay/Hair");
        hairstylePreview = GetNode<TextureRect>("Control/VBoxContainer/Hairstyle/TextureRect");
        hairSprite = GetNode<Sprite2D>("CharacterDisplay/Hair");

        outfitPreview = GetNode<TextureRect>("Control/VBoxContainer/Outfit/TextureRect");
        outfitSprite = GetNode<Sprite2D>("CharacterDisplay/Outfit");

		HairLeftArrow = GetNode<Button>("Control/VBoxContainer/Hairstyle/Left Arrow");
		HairRightArrow = GetNode<Button>("Control/VBoxContainer/Hairstyle/Right Arrow");
		HairLeftArrow.Pressed += OnLeftButtonPressed;
		HairRightArrow.Pressed += OnRightButtonPressed;

        OutfitLeftArrow = GetNode<Button>("Control/VBoxContainer/Outfit/Left Arrow");
        OutfitRightArrow = GetNode<Button>("Control/VBoxContainer/Outfit/Right Arrow");
        OutfitLeftArrow.Pressed += OnOutfitLeftButtonPressed;
        OutfitRightArrow.Pressed += OnOutfitRightButtonPressed;

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
        // Update preview image
        hairstylePreview.Texture = hairstyleImages[currentHairstyle];
        hairSprite.Texture = hairstyleImages[currentHairstyle];
        outfitPreview.Texture = outfitImages[currentOutfit];
        outfitSprite.Texture = outfitImages[currentOutfit];
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
    public void ChangeOutfit(int direction)
    {
        currentOutfit = (currentOutfit + direction) % outfitImages.Length;
        if (currentOutfit < 0)
        {
            currentOutfit = outfitImages.Length - 1;
        }
        UpdateCharacter();
    }

    // Update character appearance and preview
    /*private void UpdateOutfit()
    {
        // Update character's hair texture
        // Update preview image
        outfitPreview.Texture = outfitImages[currentOutfit];
        hairSprite.Texture = hairstyleImages[currentHairstyle];
    }*/

    // Button signals
    private void OnOutfitLeftButtonPressed()
    {
        ChangeOutfit(-1);
    }

    private void OnOutfitRightButtonPressed()
    {
        ChangeOutfit(1);
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


