using Godot;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

public partial class Global : Node
{
    public List<string> storylines = new List<string>();
	public List<string> characterL = new List<string>();
	public List<string> characterR = new List<string>();
	public List<string> highlightLR = new List<string>();
	public List<string> triggerL = new List<string>();
	public List<string> triggerR = new List<string>();
	public List<string> triggerEvent = new List<string>();
	public Dictionary<string, int> storyIdIndexMap = new Dictionary<string, int>();

	public bool multiplayer_game = false;
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
    	public string id { get; set; }
		public string Line { get; set; }
		public string LCharacters { get; set; }
		public string RCharacters { get; set; }
		public string HighlightLR { get; set; }
		public string triggerTagL { get; set; }
		public string triggerTagR { get; set; }
		public string triggerTagEvent { get; set; }
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
				characterL = data["Intro"].Select(story => story.LCharacters).ToList();
				characterR = data["Intro"].Select(story => story.RCharacters).ToList();
				highlightLR = data["Intro"].Select(story => story.HighlightLR).ToList();
				triggerL = data["Intro"].Select(story => story.triggerTagL).ToList();
				triggerR = data["Intro"].Select(story => story.triggerTagR).ToList();
				triggerEvent = data["Intro"].Select(story => story.triggerTagEvent).ToList();
				
				for (int i = 0; i < data["Intro"].Count; i++)
				{
					storyIdIndexMap[data["Intro"][i].id] = i;
				}
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