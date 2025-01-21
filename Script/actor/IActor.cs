using Godot;
using System;

public interface IActor
{
	Vector2 Velocity { get; set; }
    Vector2 GlobalPosition { get; set; }
    public void Move(Vector2 velocity);
    public bool IsOnFloor();
}
