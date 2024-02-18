using Godot;
using System;

public partial class BallBehaviour : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawnBall();
	}

	public void spawnBall()
	{
		this.LinearVelocity = new Vector2(0,0);
		this.AngularVelocity = 0f;
		this.Position = new Vector2(575,324);
		Random rand = new Random();
		int firstMove = rand.Next(0,2);
		if (firstMove == 1)
		{
			this.ApplyImpulse(new Vector2(0, 500));
		}
		else
		{
			this.ApplyImpulse(new Vector2(0, -500));
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

