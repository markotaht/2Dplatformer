using Godot;
using Godot.Collections;
using System;

public partial class Enemy : CharacterBody2D, IHookable
{
    public GrapplingHook HookObject { get; set; }

    [Export]
    private Weapon Weapon { get; set; }

    [Signal]
    public delegate void DiedEventHandler(Enemy enemy);

    bool alive = true;

    private Sprite2D Sprite;
    private Node2D body;
    public override void _Ready()
    {
        Sprite = GetNode<Sprite2D>("Body/Sprite");
        body = GetNode<Node2D>("Body");
    }
    public void GetHooked(GrapplingHook hook)
    {
        HookObject = hook;
    }

    public void Die()
    {
        if (alive)
        {
            alive = false;
            if (HookObject != null)
            {
                HookObject.UnHook();
            }

            EmitSignal(SignalName.Died, this);
        }
    }

    public void Shoot()
    {
        Weapon.Attack();
    }

    public void LookAtPosition(Vector2 pos)
    {
        Weapon.LookAt(pos);
        Vector2 sclale = body.Scale;
        if (pos.X < GlobalPosition.X)
        {
            sclale.X = -1;
        }
        else
        {
            sclale.X = 1;
        }
        body.Scale = sclale;
    }

    public void Move(Vector2 velocity)
    {
        if(velocity.X < 0)
        {
            Sprite.FlipH = true;
        } else
        {
            Sprite.FlipH = false;
        }
        Velocity = velocity;
        MoveAndSlide();
        Velocity = Vector2.Zero;
    }

    public void UnHook()
    {
        HookObject = null;
    }

    void IHookable.Hook(GrapplingHook hook)
    {
        HookObject = hook;
    }
}
