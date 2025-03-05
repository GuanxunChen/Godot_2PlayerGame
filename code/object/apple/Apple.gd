extends Area2D


# Called when the node enters the scene tree for the first time.
func _ready():
	body_entered.connect(_on_body_entered)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
	
func _on_body_entered(body):
	if body.is_in_group("Player"):  # Make sure the player is in the group
		body.add_item("Apple")  # Call function in Player
		print("Player picked up an apple!")  # Debug message
		queue_free()  # Remove apple after collection
