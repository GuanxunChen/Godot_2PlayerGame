extends Node2D
#region New Code Region

var knightwheel_skill_unlocked = false
var parry_skill_unlocked = false
var meteor_skill_unlocked = false
var starburst_skill_unlocked = false
var cross_slash_skill_unlocked = false
var attentionText = "Not Enough Skill Points!"

var sonic_slash_skill_unlocked = false
var side_step_skill_unlocked = false
var shadow_walk_skill_unlocked = false
#endregion

var skillPoints = 3
# Called when the node enters the scene tree for the first time.
func _ready():

	$Panel/Attack/BackAttackButton.visible = false
	$Panel/Passive/BackPassiveButton.visible = false
	$Panel/Pet/BackPetButton.visible = false
	$Panel/Exploration/BackExplorationButton.visible = false
	$Panel/Attack/AttackControl.visible = false
	$Panel/Passive/PassiveControl.visible = false
	$Panel/Pet/PetControl.visible = false
	$Panel/Exploration/ExplorationControl.visible = false
	$Panel/Attack/SwordLine.visible = false

	$Panel/SkillPoints.visible = false
	$"Panel/Attack/AttackControl/Sword/Starburst Stream".disabled = true
	$"Panel/Attack/AttackControl/Sword/Meteor Strike".disabled = true
	$"Panel/Attack/AttackControl/Sword/Shadow Walk".disabled = true
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	$Panel/SkillPoints/points.text = str(skillPoints)

func attackButtonPressed():
	$Panel/Camera2D.set_position(Vector2(960/2, 540/2))
	$Panel/Camera2D.set_zoom(Vector2(2.0, 2.0))
	$Panel/TextureButton.visible = false
	$Panel/Attack/BackAttackButton.visible = true
	$Panel/Attack/AttackControl.visible = true
	$Panel/Attack/AttackLabel.visible = false
	$Panel/Attack.disabled = true
	$Panel/Attack/SwordLine.visible = true
	$Panel/SkillPoints.visible = true
	$Panel/SkillPoints.set_position(Vector2(832, 0))
	
func backButtonPressed():
	$Panel/Camera2D.set_position(Vector2(960, 540))
	$Panel/Camera2D.set_zoom(Vector2(1.0, 1.0))
	$Panel/TextureButton.visible = true
	$Panel/Attack/BackAttackButton.visible = false
	$Panel/Passive/BackPassiveButton.visible = false
	$Panel/Pet/BackPetButton.visible = false
	$Panel/Exploration/BackExplorationButton.visible = false
	$Panel/Attack.visible = true
	$Panel/Attack/AttackControl.visible = false
	$Panel/Passive/PassiveControl.visible = false
	$Panel/Pet/PetControl.visible = false;
	$Panel/Exploration/ExplorationControl.visible = false;
	$Panel/Attack/AttackLabel.visible = true;
	$Panel/Attack.disabled = false;
	$Panel/Attack/SwordLine.visible = false;
	$Panel/Passive.disabled = false;
	$Panel/Pet.disabled = false;
	$Panel/Exploration.disabled = false;
	$Panel/SkillPoints.visible = false;
	
func passiveButtonPressed():
	$Panel/Camera2D.set_position(Vector2(960/2, 540 + (540/2)))
	$Panel/Camera2D.set_zoom(Vector2(2.0, 2.0))
	$Panel/SkillPoints.visible = false;
	$Panel/Passive/BackPassiveButton.visible = true;
	$Panel/Passive.disabled = true;
	$Panel/Passive/PassiveControl.visible = true;
	$Panel/SkillPoints.visible = true;
	$Panel/SkillPoints.set_position(Vector2(832, 540))
	
func petButtonPressed():
	$Panel/Camera2D.set_position(Vector2(1440, 540/2))
	$Panel/Camera2D.set_zoom(Vector2(2.0, 2.0))
	$Panel/TextureButton.visible = false
	$Panel/Pet/BackPetButton.visible = true
	$Panel/Pet.disabled = true
	$Panel/Pet/PetControl.visible = true
	$Panel/SkillPoints.visible = true
	$Panel/SkillPointsl.set_position(Vector2(1792, 0))
	
func explorationButtonPressed():
	$Panel/Camera2D.set_position(Vector2(960 + (960/2), 540 + (540/2)))
	$Panel/Camera2D.set_zoom(Vector2(2.0, 2.0))
	$Panel/TextureButton.visible = false
	$Panel/Exploration/BackExplorationButton.visible = true
	$Panel/Exploration.disabled = true
	$Panel/Exploration/ExplorationControl.visible = true
	$Panel/SkillPoints.visible = true
	$Panel/SkillPoints.set_position(Vector2(1792, 540))

func crossSlashToggled(toggled_on: bool):
	if toggled_on:
		if skillPoints < 1:
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Cross Slash".button_pressed = false
		else:
			skillPoints -= 1
			$"Panel/Attack/AttackControl/Sword/Starburst Stream".disabled = false
			cross_slash_skill_unlocked = true
	else:
		if cross_slash_skill_unlocked:
			skillPoints += 1
			if $"Panel/Attack/AttackControl/Sword/Starburst Stream".button_pressed:  # Check if it's currently toggled on
				$"Panel/Attack/AttackControl/Sword/Starburst Stream".button_pressed = false  # Force it to turn off
			$"Panel/Attack/AttackControl/Sword/Starburst Stream".disabled = true  # Disable Starburst Stream after refunding
			cross_slash_skill_unlocked = false
			
func starBurstStreamToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 2:
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Starburst Stream".button_pressed = false
		else:
			skillPoints -= 2
			$"Panel/Attack/AttackControl/Sword/Meteor Strike".disabled = false
			starburst_skill_unlocked = true
	else:
		if starburst_skill_unlocked:
			skillPoints += 2
			if $"Panel/Attack/AttackControl/Sword/Meteor Strike".button_pressed:
				$"Panel/Attack/AttackControl/Sword/Meteor Strike".button_pressed = false
			$"Panel/Attack/AttackControl/Sword/Meteor Strike".disabled = true
			starburst_skill_unlocked = false

func meteorStrikeToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 3:
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Meteor Strike".button_pressed = false
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
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$Panel/Attack/AttackControl/Sword/Parry.button_pressed = false
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
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Knight's Wheel".button_pressed = false
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
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Sonic Slash".button_pressed = false
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
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Side Step".button_pressed = false
		else:
			skillPoints -= 1
			$"Panel/Attack/AttackControl/Sword/Shadow Walk".disabled = false
			side_step_skill_unlocked = true
	else:
		if side_step_skill_unlocked:
			skillPoints += 1
			if $"Panel/Attack/AttackControl/Sword/Shadow Walk".button_pressed:  # Check if it's currently toggled on
				$"Panel/Attack/AttackControl/Sword/Shadow Walk".button_pressed = false  # Force it to turn off
			$"Panel/Attack/AttackControl/Sword/Shadow Walk".disabled = true  # Disable Starburst Stream after refunding
			side_step_skill_unlocked = false

func shadowWalkToggle(toggled_on: bool):
	if toggled_on:
		if skillPoints < 4:
			$Panel/Popup.show()
			$Panel/Popup/Attention.text = attentionText
			$"Panel/Attack/AttackControl/Sword/Shadow Walk".button_pressed = false
		else:
			skillPoints -= 3
			shadow_walk_skill_unlocked = true
	else:
		if shadow_walk_skill_unlocked:
			shadow_walk_skill_unlocked = false
			skillPoints += 3
