extends Panel

# Declare member variables here.
var texts = []
var current_text_index = 0

func _ready():
	# Initialize the list of texts
	texts = [
		"Welcome to the game!",
		"This is the first level.",
		"Good luck and have fun!"
	]
	
	# Get the RichTextLabel node inside the Panel
	var label = $Label

	# Set the initial text
	current_text_index = 0
	label.text = texts[current_text_index]

	# Show the panel initially
	show_panel()

func _input(event):
	# Check for screen click, Spacebar, or Enter key to proceed to the next text
	if event is InputEventMouseButton and event.pressed:
		proceed_to_next_text()
	

func proceed_to_next_text():
	current_text_index += 1

	if current_text_index < texts.size():
		# Update the label with the next text
		$Label.text = texts[current_text_index]
	else:
		# Hide the panel if all texts have been shown
		hide_panel()

func show_panel():
	visible = true # Show the panel

func hide_panel():
	visible = false # Hide the panel
