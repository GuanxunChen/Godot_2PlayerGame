extends Node2D

var fade_rect : TextureRect
var fade_rect2 : TextureRect
var background : TextureRect

func _ready() -> void:
	fade_rect = $FadeIn
	fade_rect2 = $FadeOut
	background = $Background

	if fade_rect:
		fade_rect.z_index = 1  # Bring to the top layer
		await FadeIn(fade_rect, 0.001, 0.01)

	#await get_tree().create_timer(5.0).timeout
	#background.modulate = Color(1, 1, 1, 0)

	if fade_rect2:
		fade_rect2.z_index = 1  # Bring to the top layer
		await FadeOut(fade_rect2, 0.001, 0.01)

	await get_tree().create_timer(5.0).timeout

	if background:
		background.z_index = 1  # Bring to the top layer
		await FadeOut(background, 0.01, 0.01)

func FadeIn(rect: TextureRect, speed: float, timer: float) -> void:
	rect.z_index = 1  # Ensure it's on top
	var alpha = 1.0
	while alpha > 0:
		rect.modulate = Color(1, 1, 1, alpha)
		await get_tree().create_timer(timer).timeout
		alpha -= speed
		if alpha < 0:
			alpha = 0

	rect.modulate = Color(1, 1, 1, 0)
	rect.z_index = 0  # Reset the ZIndex after fading in

func FadeOut(rect: TextureRect, speed: float, timer: float) -> void:
	rect.z_index = 1  # Ensure it's on top
	var alpha = 0.0
	while alpha < 1.0:
		rect.modulate = Color(1, 1, 1, alpha)
		await get_tree().create_timer(timer).timeout
		alpha += speed
		if alpha > 1:
			alpha = 1

	rect.modulate = Color(1, 1, 1, 1)
	rect.z_index = 0  # Reset the ZIndex after fading out
