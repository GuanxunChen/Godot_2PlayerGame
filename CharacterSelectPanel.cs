using Godot;
using System;

public partial class CharacterSelectPanel : PopupPanel
{
	private TextureButton _character1Button;
    private TextureButton _character2Button;
	private TextureButton _character3Button;
	private TextureButton _character4Button;
    private TextureRect _displayTextureRect;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_character1Button = GetNode<TextureButton>("VBoxContainer/HBoxContainer/Character1Button");
		_character2Button = GetNode<TextureButton>("VBoxContainer/HBoxContainer/Character2Button");
		_character3Button = GetNode<TextureButton>("VBoxContainer/HBoxContainer2/Character3Button");
		_character4Button = GetNode<TextureButton>("VBoxContainer/HBoxContainer2/Character4Button");

		_displayTextureRect = GetNode<TextureRect>("/root/Game View/Image Process/CharacterL");

		_character1Button.Pressed += OnCharacter1ButtonPressed;
		_character2Button.Pressed += OnCharacter2ButtonPressed;
		_character3Button.Pressed += OnCharacter3ButtonPressed;
		_character4Button.Pressed += OnCharacter4ButtonPressed;
	}

	private void OnCharacter1ButtonPressed()
	{
		_displayTextureRect.Texture = _character1Button.TextureNormal;
		Hide();
	}

	private void OnCharacter2ButtonPressed()
	{
		_displayTextureRect.Texture = _character2Button.TextureNormal;
		Hide();
	}

	private void OnCharacter3ButtonPressed()
	{
		_displayTextureRect.Texture = _character3Button.TextureNormal;
		Hide();
	}

	private void OnCharacter4ButtonPressed()
	{
		_displayTextureRect.Texture = _character4Button.TextureNormal;
		Hide();
	}
	
}
