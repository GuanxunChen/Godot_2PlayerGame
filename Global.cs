using Godot;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public partial class Global : Node
{
	public List<string> storylines = new List<string>();
    public int currentLine = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        storylines.Add("1st");
        storylines.Add("2nd");
        storylines.Add("3rd");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
/*
public class storyLines
{
    public string LeftCharacter { get; set; }
    public string RightCharacters { get; set; }
    public string currentLine { get; set; }
    public string HighlightLorR { get; set; }
}

public partial class Global : Node
{
	public List<storyLines> storylines = new List<storyLines>();
    public int currentLine = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        LoadStory("res://story.json");
	}

	private void LoadStory(string filePath)
    {

    }
}
*/
