extends Node2D
var camera
var attackButton
var playerButton
var backAttackButton
var attackControl
var attackLabel
var swordLine
var skillPointsLabel
var passiveControl
var petControl
var explorationControl
var backPassiveButton
var backPetButton
var backExplorationButton
var points
var passiveButton
var petButton
var explorationButton
var starBurstStream

var skillPoints = 3
# Called when the node enters the scene tree for the first time.
func _ready():
	camera = $Panel/Camera2D
	attackButton = $Panel/Attack
	playerButton = $Panel/TextureButton
	petButton = $Panel/Pet
	passiveButton = $Panel/Passive
	explorationButton = $Panel/Exploration
	backAttackButton = $Panel/Attack/Button
	attackControl = $Panel/Attack/AttackControl
	attackLabel = $Panel/Attack/Label
	swordLine = $Panel/Attack/SwordLine
	skillPointsLabel = $Panel/SkillPoints
	passiveControl = $Panel/Passive/PassiveControl
	petControl = $Panel/Pet/PetControl
	explorationControl = $Panel/Exploration/ExplorationControl
	backPetButton = $Panel/Pet/Button
	backPassiveButton = $Panel/Passive/Button
	backExplorationButton = $Panel/Exploration/Button
	points = $Panel/SkillPoints/points
	starBurstStream = $"Panel/Attack/AttackControl/Sword/Starburst Stream"

	backAttackButton.visible = false
	backPassiveButton.visible = false
	backPetButton.visible = false
	backExplorationButton.visible = false
	attackControl.visible = false
	passiveControl.visible = false
	petControl.visible = false
	explorationControl.visible = false
	swordLine.visible = false

	skillPointsLabel.visible = false
	starBurstStream.disabled = true
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	points.text = str(skillPoints)

func attackButtonPressed():
	camera.set_position(Vector2(960/2, 540/2))
	camera.set_zoom(Vector2(2.0, 2.0))
	playerButton.visible = false
	backAttackButton.visible = true
	attackControl.visible = true
	attackLabel.visible = false
	attackButton.disabled = true
	swordLine.visible = true
	skillPointsLabel.visible = true
	skillPointsLabel.set_position(Vector2(832, 0))
	
func backButtonPressed():
	camera.set_position(Vector2(960, 540))
	camera.set_zoom(Vector2(1.0, 1.0))
	playerButton.visible = true
	backAttackButton.visible = false
	backPassiveButton.visible = false
	backPetButton.visible = false
	backExplorationButton.visible = false
	attackButton.visible = true
	attackControl.visible = false
	passiveControl.visible = false
	petControl.visible = false;
	explorationControl.visible = false;
	attackLabel.visible = true;
	attackButton.disabled = false;
	swordLine.visible = false;
	passiveButton.disabled = false;
	petButton.disabled = false;
	explorationButton.disabled = false;
	skillPointsLabel.visible = false;
	
func passiveButtonPressed():
	camera.set_position(Vector2(960/2, 540 + (540/2)))
	camera.set_zoom(Vector2(2.0, 2.0))
	playerButton.visible = false;
	backPassiveButton.visible = true;
	passiveButton.disabled = true;
	passiveControl.visible = true;
	skillPointsLabel.visible = true;
	skillPointsLabel.set_position(Vector2(832, 540))
	
func petButtonPressed():
	camera.set_position(Vector2(1440, 540/2))
	camera.set_zoom(Vector2(2.0, 2.0))
	playerButton.visible = false
	backPetButton.visible = true
	petButton.disabled = true
	petControl.visible = true
	skillPointsLabel.visible = true
	skillPointsLabel.set_position(Vector2(1792, 0))
	
func explorationButtonPressed():
	camera.set_position(Vector2(960 + (960/2), 540 + (540/2)))
	camera.set_zoom(Vector2(2.0, 2.0))
	playerButton.visible = false
	backExplorationButton.visible = true
	explorationButton.disabled = true
	explorationControl.visible = true
	skillPointsLabel.visible = true
	skillPointsLabel.set_position(Vector2(1792, 540))

func crossSlashToggled(toggled_on: bool):
	if toggled_on:
		skillPoints -= 1
		starBurstStream.disabled = false
	else:
		skillPoints += 1
		if starBurstStream.button_pressed:  # Check if it's currently toggled on
			starBurstStream.button_pressed = false  # Force it to turn off
			#starBurstStreamToggle(false)  # Call the function to refund points
		starBurstStream.disabled = true  # Disable Starburst Stream after refunding
			
func starBurstStreamToggle(toggled_on: bool):
	if toggled_on:
		skillPoints -= 2
	else:
		skillPoints += 2
