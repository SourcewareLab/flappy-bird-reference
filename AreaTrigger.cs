using Godot;
using System;

public partial class AreaTrigger : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node body)
	{
		var groups = body.GetGroups();
		GD.Print($"{body.Name} is in groups: {string.Join(", ", groups)}");	
		
		if (body.IsInGroup("flappy"))
    		{
    			GD.Print("Passed");
    		}
	}
}
