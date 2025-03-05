extends StaticBody2D


# Called when the node enters the scene tree for the first time.

func _ready():
	$Area2D.body_entered.connect(_on_body_entered)
	$Area2D.body_exited.connect(_on_body_exited)
	 # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if player_nearby and Input.is_action_just_pressed("interact"):  # "F" key
		drop_apple()

@export var apple_scene: PackedScene  # Drag your Apple.tscn here in the Inspector
var player_nearby = false  # Track if player is near the tree

func _on_body_entered(body):
	if body.is_in_group("Player"):  # Make sure your player is in the "Player" group
		player_nearby = true

func _on_body_exited(body):
	if body.is_in_group("Player"):
		player_nearby = false

func drop_apple():
	if apple_scene:
		var apple = apple_scene.instantiate()  # Create an apple instance
		apple.position = position + Vector2(0, 20)  # Drop it below the tree
		get_parent().add_child(apple)  # Add to scene
	queue_free()  # Remove tree after interaction (optional)
