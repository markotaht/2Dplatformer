using Godot;
using System;

public partial class KeyPromt : Sprite2D
{
	[Export]
	private Label promptLabel { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Collections.Array<InputEvent> inputEvents = InputMap.ActionGetEvents("interact");
		InputEvent event0 = inputEvents[0];
		promptLabel.Text = event0.AsText();
	}
}
