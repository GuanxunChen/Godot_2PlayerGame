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

	backAttackButton.visible = false
	backPassiveButton.visible = false
	backPetButton.visible = false
	backExplorationButton.visible = false
	attackControl.visible = false
	passiveControl.visible = false
	petControl.visible = false
	explorationControl.visible = false
	swordLine.visible = false
	
	points.text = str(skillPoints);

	skillPointsLabel.visible = false;
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

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
