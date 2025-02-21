using Godot;
using System;
using Godot.Collections;

public partial class FlappyBody : RigidBody2D
{
	[Export] float speed = 200f;

	[Export] float jumpPower = 550f;
	
	//time before game reloads
	[Export] float resetTimer = 1f;

	private Vector2 movementThisFrame = new Vector2();
	private Vector2 jumpImpulse = new Vector2();
	private bool hasCrashed = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		movementThisFrame.X = speed;
		jumpImpulse.Y = -jumpPower;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		if (hasCrashed)
		{ 
			return;
		}
		
		movementThisFrame.Y = LinearVelocity.Y;

		LinearVelocity = movementThisFrame;
	}

	public override void _Input(InputEvent @event)
	{
		if (hasCrashed)
		{
			return;
		}
		
		if (@event is InputEventKey eventKey)
		{
			if (eventKey.Pressed && eventKey.Keycode == Key.Space)
			{
				//canceling current down/up velocity
				movementThisFrame.Y = 0f;
				LinearVelocity = movementThisFrame;
				
				ApplyImpulse(jumpImpulse);
			}
		}
	}

	public void StopPlayer()
	{
		hasCrashed = true;

		LinearVelocity = Vector2.Zero;
		GravityScale = 0f;
		LockRotation = false;
	}
}
				
