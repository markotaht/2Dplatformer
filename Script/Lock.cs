using Godot;
using System;

public partial class Lock : Area2D
{
    [Export]
    private CanvasItem Key { get; set; }

    [Export]
    private DoorController DoorController { get; set; }

    private PlayerInventory inventory;
    public override void _Ready()
    {
        inventory = GetNode<PlayerInventory>("/root/PlayerInventory");
    }

    public void _on_body_entered(Node2D body)
	{
		if (body is Player && inventory.HasKey)
		{
            Key.Visible = true;
            inventory.HasKey = false;
            DoorController.OpenDoor();
		}
	}
}
