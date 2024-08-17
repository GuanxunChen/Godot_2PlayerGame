using Godot;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

public partial class Global : Node
{
    public List<string> storylines = new List<string>();
    public int currentLine = 0;

    public override void _Ready()
    {
        LoadStory();
    }

    private void LoadStory()
	{
		string filePath = ProjectSettings.GlobalizePath("res://story.json");
		try
		{
			var json = File.ReadAllText(filePath);
			var data = JsonConvert.DeserializeObject<Dictionary<string, List<StoryLine>>>(json);

			if (data.ContainsKey("Intro"))
			{
				storylines = data["Intro"].Select(story => story.Line).ToList(); // Assign to public field
			}
			else
			{
				GD.PrintErr("The specified section 'Intro' was not found in the JSON file.");
			}
		}
		catch (Exception ex)
		{
			GD.PrintErr("Error loading story: " + ex.Message);
		}
	}
}

public class StoryLine
{
    public string LCharacters { get; set; }
    public string RCharacters { get; set; }
    public string HighlightL_R { get; set; }
    public string Line { get; set; }
}
