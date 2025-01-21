using Godot;
using System;

public partial class Door : AnimatedSprite2D
{
	public void _on_animation_looped()
	{
        (GetParent() as DoorController).DoorIsOpen();
        Frame = 4;
    }
}
