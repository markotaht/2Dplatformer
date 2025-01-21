using Godot;
using System;

public partial class KeyItem : Area2D
{

    private PlayerInventory inventory;
    public override void _Ready()
    {
        inventory = GetNode<PlayerInventory>("/root/PlayerInventory");
    }
    public void _on_body_entered(Node2D body)
	{
		if(body is Player)
		{
            inventory.HasKey = true;
            QueueFree();
		}
	}
}
