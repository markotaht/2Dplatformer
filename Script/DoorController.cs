using Godot;
using System;

public partial class DoorController : Node2D
{
	[Export]
	private AnimatedSprite2D DoorSprite { get; set; }

	[Export]
	private CollisionShape2D DoorCollider { get; set; }
	
	public void OpenDoor()
	{
		DoorSprite.Play("DoorOpen");
	}

	public void DoorIsOpen()
	{
		DoorSprite.Stop();
		DoorCollider.Disabled = true;
	}
}
