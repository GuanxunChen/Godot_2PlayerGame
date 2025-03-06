extends Node2D
#region New Code Region
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
var meteorStrike
var popup
var attention
var crossSlash
var knightsWheel
var parry
var knightwheel_skill_unlocked = false
var parry_skill_unlocked = false
var meteor_skill_unlocked = false
var starburst_skill_unlocked = false
var cross_slash_skill_unlocked = false
var attentionText = "Not Enough Skill Points!"
var sonicSlash
var sonic_slash_skill_unlocked = false
var side_step
var side_step_skill_unlocked = false
var shadow_walk
var shadow_walk_skill_unlocked = false
#endregion

var skillPoints = 3
# Called when the node enters the scene tree for the first time.
func _ready():
#region New Code Region
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
	meteorStrike = $"Panel/Attack/AttackControl/Sword/Meteor Strike"
	popup = $Panel/Popup
	attention = $Panel/Popup/Attention
	crossSlash = $"Panel/Attack/AttackControl/Sword/Cross Slash"
	knightsWheel = $"Panel/Attack/AttackControl/Sword/Knight's Wheel"
	parry = $Panel/Attack/AttackControl/Sword/Parry
	sonicSlash = $"Panel/Attack/AttackControl/Sword/Sonic Slash"
	side_step = $"Panel/Attack/AttackControl/Sword/Side Step"
	shadow_walk = $"Panel/Attack/AttackControl/Sword/Shadow Walk"
#endregion

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
	meteorStrike.disabled = true
	shadow_walk.disabled = true
	
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
		if skillPoints < 1:
			popup.show()
			attention.text = attentionText
			crossSlash.button_pressed = false
		else:
			skillPoints -= 1
			starBurstStream.disabled = false
			cross_slash_skill_unlocked = true
	else:
		if cross_slash_skill_unlocked:
			skillPoints += 1
			if starBurstStream.button_pressed:  # Check if it's currently toggled on
				starBurstStream.button_pressed = false  # Force it to turn off
			starBurstStream.disabled = true  # Disable Starburst Stream after refunding
			cross_slash_skill_unlocked = false
			
func starBurstStreamToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 2:
			popup.show()
			attention.text = attentionText
			starBurstStream.button_pressed = false
		else:
			skillPoints -= 2
			meteorStrike.disabled = false
			starburst_skill_unlocked = true
	else:
		if starburst_skill_unlocked:
			skillPoints += 2
			if meteorStrike.button_pressed:
				meteorStrike.button_pressed = false
			meteorStrike.disabled = true
			starburst_skill_unlocked = false

func meteorStrikeToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 3:
			popup.show()
			attention.text = attentionText
			meteorStrike.button_pressed = false
		else:
			skillPoints -= 3
			meteor_skill_unlocked = true
	else:
		if meteor_skill_unlocked:
			meteor_skill_unlocked = false
			skillPoints += 3
		
func parryToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 2:
			popup.show()
			attention.text = attentionText
			parry.button_pressed = false
		else:
			skillPoints -= 2
			parry_skill_unlocked = true
	else:
		if parry_skill_unlocked:
			skillPoints += 2
			parry_skill_unlocked = false

func knightsWheelToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 3:
			popup.show()
			attention.text = attentionText
			knightsWheel.button_pressed = false
		else:
			skillPoints -= 3
			knightwheel_skill_unlocked = true
	else:
		if knightwheel_skill_unlocked:
			skillPoints += 3
			knightwheel_skill_unlocked = false

func sonicSlashToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 3:
			popup.show()
			attention.text = attentionText
			sonicSlash.button_pressed = false
		else:
			skillPoints -= 3
			sonic_slash_skill_unlocked = true
	else:
		if sonic_slash_skill_unlocked:
			sonic_slash_skill_unlocked = false
			skillPoints += 3

func sideStepToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 1:
			popup.show()
			attention.text = attentionText
			side_step.button_pressed = false
		else:
			skillPoints -= 1
			shadow_walk.disabled = false
			side_step_skill_unlocked = true
	else:
		if side_step_skill_unlocked:
			skillPoints += 1
			if shadow_walk.button_pressed:  # Check if it's currently toggled on
				shadow_walk.button_pressed = false  # Force it to turn off
			shadow_walk.disabled = true  # Disable Starburst Stream after refunding
			side_step_skill_unlocked = false

func shadowWalkToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 4:
			popup.show()
			attention.text = attentionText
			shadow_walk.button_pressed = false
		else:
			skillPoints -= 3
			shadow_walk_skill_unlocked = true
	else:
		if shadow_walk_skill_unlocked:
			shadow_walk_skill_unlocked = false
			skillPoints += 3
