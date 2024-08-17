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
		// Load the storylines as story
        LoadStory();
    }
	
	/// =====================================
	/// (JSON) StoryLine Class
	/// =====================================
	public class StoryLine
	{
		// Getter and Setters
		public string LCharacters { get; set; }
		public string RCharacters { get; set; }
		public string HighlightL_R { get; set; }
		public string Line { get; set; }
	}

    /// =====================================
	/// Story Loader Function
	/// =====================================
    private void LoadStory()
	{
		// Linking to storyline files
		string filePath = ProjectSettings.GlobalizePath("res://story.json");

		// Check if story exist
		try
		{
			var json = File.ReadAllText(filePath);
			var data = JsonConvert.DeserializeObject<Dictionary<string, List<StoryLine>>>(json);

			// Load Intro section
			if (data.ContainsKey("Intro"))
			{
				// Store to storylines
				storylines = data["Intro"].Select(story => story.Line).ToList();
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