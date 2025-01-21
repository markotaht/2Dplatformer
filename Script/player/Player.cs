using Godot;

public partial class Player : CharacterBody2D, IActor
{
    public void Move(Vector2 velocity)
    {
        Velocity = velocity;
		MoveAndSlide();
    }
}
