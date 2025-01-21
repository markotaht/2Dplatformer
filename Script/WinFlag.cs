using Godot;
using System;

public partial class WinFlag : Sprite2D
{

	[Export]
	private Label winText;
	// Called when the node enters the scene tree for the first time.

	public void _on_area_2d_body_entered(Node2D body)
	{
		if(body is Player)
		{
			winText.Visible = true;
		}
	}
}
