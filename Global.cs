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
}

/*
public class storyLine
{
    public string LCharacters { get; set; }
    public string RCharacters { get; set; }
    public string HighlightL { get; set; }
    public string Line { get; set; }
}

public partial class Global : Node
{
	public List<storyLine> loadedStory = new List<storyLine>();
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