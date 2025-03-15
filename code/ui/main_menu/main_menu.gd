extends Control

@onready var game_scene : PackedScene = load("res://code/game.tscn")
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func _on_start_game_pressed():
	get_tree().change_scene_to_packed(game_scene)


func _on_quit_pressed():
	get_tree().quit()
