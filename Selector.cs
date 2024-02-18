using Godot;
using GodotPlugins.Game;
using System;
using System.Data.SqlTypes;

public partial class Selector : TextureRect
{
	public string selectedOption = "Play";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Position = new Vector2(490, 190);
	}

    public override void _Input(InputEvent @event)
    {
		if (@event is InputEventKey)
		{
			if (@event.IsActionPressed("ui_up"))
			{
				this.Position = new Vector2(490,190);
				Console.Beep();
				selectedOption = "Play";
			}
			else if (@event.IsActionPressed("ui_down"))
			{
				this.Position = new Vector2(490,300);
				Console.Beep();
				selectedOption = "Exit";
			}
			else if (@event.IsActionPressed("ui_accept"))
			{
				if (selectedOption == "Play")
				{
					//Go to game
					GetTree().ChangeSceneToFile("res://game.tscn");
				}
				else
				{
					//Exit Game
					GetTree().Quit();
				}
			}
		}
        base._Input(@event);
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
