using Godot;
using System;
using System.Threading;

public partial class ScoreBehaviour : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public Label labelScore1;
	public Label labelScore2;
	public Node2D scoreCounter;
	public PackedScene BallScene;
	public override void _Ready()
	{
		labelScore1 = this.GetParent().GetChild<Label>(8);
		labelScore2 = this.GetParent().GetChild<Label>(7);
		scoreCounter = this.GetParent().GetChild<Node2D>(11);

		BallScene = GD.Load<PackedScene>("res://ball.tscn");
		// RigidBody2D instance = (RigidBody2D)BallScene.Instantiate();
		// //this.GetParent().AddChild(instance);
		// CallDeferred("add_child", instance);
		// instance.Position = new Vector2(575,324);
		// //instance.Call("spawnBall");
		// GD.Print("Spawned ball "+instance);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void _on_body_entered(Node node)
	{
		if (node is RigidBody2D)
		{
			switch (this.Name)
			{
				case "SCORETARGET1":
					//Get Score
					int score2 = (int)scoreCounter.GetMeta("SCORE2") + 1;

					//Update Score
					scoreCounter.SetMeta("SCORE2", (Variant)score2);
					labelScore2.Text = "SCORE: "+score2;
					break;
				case "SCORETARGET2":
					//Get Score
					int score1 = (int)scoreCounter.GetMeta("SCORE1") + 1;

					//Update Score
					scoreCounter.SetMeta("SCORE1", (Variant)score1);
					labelScore1.Text = "SCORE: "+score1;
					break;
			}
			//Reset Paddle Positions
			StaticBody2D player1 = this.GetParent().GetNode<StaticBody2D>("Player1");
			player1.Position = new Vector2(-24,player1.Position.Y);
			StaticBody2D player2 = this.GetParent().GetNode<StaticBody2D>("Player2");
			player2.Position = new Vector2(-24,player2.Position.Y);

			OS.DelayMsec(2000);

			//Respawn Ball
			node.QueueFree();
			RigidBody2D newBall = (RigidBody2D)BallScene.Instantiate();
			//this.GetParent().AddChild(newBall);
			this.GetParent().CallDeferred("add_child", newBall);
			newBall.Call("spawnBall");
			
		}
	}
}
