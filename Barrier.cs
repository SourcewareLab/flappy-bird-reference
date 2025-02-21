using Godot;
using System;
using System.Text;

public partial class Barrier : Node2D
{
	[Export] NinePatchRect bottomBarrierSprite;

	[Export] float groundHeight;

	private bool hasSetSprite = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (hasSetSprite)
		{
			return;
		}

		if (bottomBarrierSprite != null)
		{
			hasSetSprite = true;
			Vector2 newSize = bottomBarrierSprite.Size;
			newSize.Y = groundHeight - bottomBarrierSprite.GlobalPosition.Y;
			bottomBarrierSprite.Size = newSize;
		}
	}
}
