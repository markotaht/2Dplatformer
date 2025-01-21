using Godot;
using System;

public partial class PlayerController : Node
{
	private IActor Actor { get; set; }

    [Export]
    public PlayerData PlayerData { get; set; }

    private Timer coyoteTimer;

    private Global global;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Actor = GetParent<IActor>();
        coyoteTimer = GetParent().GetNode<Timer>("CoyoteTimer");
        global = GetNode<Global>("/root/Global");
    }

    public override void _PhysicsProcess(double delta)
	{
        Vector2 velocity = Actor.Velocity;

        if (Input.IsActionJustPressed("ui_jump") && CanJump())
        {
            velocity.Y = -PlayerData.JumpVelocity;
        }

        if (!PlayerData.Hooked)
        {
            Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            if(global.IsClimbing)
            {
                velocity.Y = direction.Y * PlayerData.Speed;
            } else
            {
                velocity.Y += PlayerData.Gravity * (float)delta;
            }
            velocity.X = direction.X * PlayerData.Speed;
        }
        else
        {
            Vector2 disitance = PlayerData.HookPoint - Actor.GlobalPosition;
            if (disitance.LengthSquared() > 100)
            {
                Vector2 dir = disitance.Normalized();
                velocity = dir * PlayerData.Speed * 4;
            }
            else
            {
                velocity = Vector2.Zero;
            }
        }

        bool wasOnFloor = Actor.IsOnFloor();
        Actor.Move(velocity);
        if (!Actor.IsOnFloor() && wasOnFloor)
        {
            coyoteTimer.Start();
        }
        
    } 

    private bool CanJump()
    {
        return Actor.IsOnFloor() || !coyoteTimer.IsStopped() || PlayerData.Hooked;
    }
}
