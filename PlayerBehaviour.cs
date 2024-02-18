using Godot;
using System;

public partial class PlayerBehaviour : Godot.StaticBody2D
{
	float startY;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startY = this.Position.Y;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed(this.Name+"_Move_Left") && this.Position.X + (this.GetChild<Sprite2D>(1).Texture.GetWidth()/2) > -420)
		{
			GD.Print("Moving Left");
			this.Position = new Vector2(this.Position.X-5,this.Position.Y);
			//this.LinearVelocity = new Vector2(-100,0);
		}
		else if (Input.IsActionPressed(this.Name+"_Move_Right") && this.Position.X + (this.GetChild<Sprite2D>(1).Texture.GetWidth()/2) < 540)
		{
			this.Position = new Vector2(this.Position.X+5,this.Position.Y);
			//this.LinearVelocity = new Vector2(100,0);
		}
		this.Position = new Vector2(this.Position.X,startY);

	}
}
