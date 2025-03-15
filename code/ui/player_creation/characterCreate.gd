extends Node2D

var current_hairstyle: int = 0
var hairstyle_images: Array = [
	preload("res://art/temp,testing/characterCreation/hairstyles/hair1.jpg"),
	preload("res://art/temp,testing/characterCreation/hairstyles/hair2.jpg"),
	preload("res://art/temp,testing/characterCreation/hairstyles/hair3.jpg")
]

var current_outfit: int = 0
var outfit_images: Array = [
	preload("res://art/temp,testing/characterCreation/outfits/outfit1.png"),
	preload("res://art/temp,testing/characterCreation/outfits/outfit2.png"),
	preload("res://art/temp,testing/characterCreation/outfits/outfit3.png"),
	preload("res://art/temp,testing/characterCreation/outfits/outfit4.png")
]
var hairColor = Color(1, 1, 1)

# Called when the node enters the scene tree for the first time.
func _ready():
	update_character()

func change_hairstyle(direction: int) -> void:
	current_hairstyle = (current_hairstyle + direction) % hairstyle_images.size()
	if current_hairstyle < 0:
		current_hairstyle = hairstyle_images.size() - 1
	update_character()

func update_character() -> void:
		# Update character's hair texture
		# Update preview image
		$Control/VBoxContainer/Hairstyle/HairStylePreview.texture = hairstyle_images[current_hairstyle]
		$CharacterDisplay/Hair.texture = hairstyle_images[current_hairstyle]
		$Control/VBoxContainer/Outfit/OutfitPreview.texture = outfit_images[current_outfit]
		$CharacterDisplay/Outfit.texture = outfit_images[current_outfit]

func _on_hair_style_left_arrow_pressed():
	change_hairstyle(-1)

func _on_hair_style_right_arrow_pressed():
	change_hairstyle(1)

func change_outfit(direction : int) -> void:
		current_outfit = (current_outfit + direction) % outfit_images.size()
		if (current_outfit < 0):
			current_outfit = outfit_images.size() - 1
		update_character()

func _on_outfit_left_arrow_pressed():
	change_outfit(-1)

func _on_outfit_right_arrow_pressed():
	change_outfit(1)

func _on_red_slider_value_changed(value):
	update_hair_color()

func _on_green_slider_value_changed(value):
	update_hair_color()

func _on_blue_slider_value_changed(value):
	update_hair_color()

func update_hair_color() -> void:
	hairColor = Color($Control/VBoxContainer/redSlider.value, 
	$Control/VBoxContainer/greenSlider.value, 
	$Control/VBoxContainer/blueSlider.value)
	
	$CharacterDisplay/Hair.modulate = Color($Control/VBoxContainer/redSlider.value, 
	$Control/VBoxContainer/greenSlider.value, 
	$Control/VBoxContainer/blueSlider.value)
