using Godot;
using System;

public partial class KillLockParticle : Node2D
{
	public Vector2 End { get; set; }

	public KillLock Target { get; set; }
	// Called when the node enters the scene tree for the first time.

    public override void _PhysicsProcess(double delta)
    {
		Vector2 dir = (End - GlobalPosition).Normalized();
		Position = Position + dir;
    }

	public void _on_area_2d_area_entered(Area2D area)
	{
		if(area == Target)
		{
			Target.ReduceHealth();
			QueueFree();
		}
	}
}
