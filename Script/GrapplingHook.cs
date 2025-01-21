using Godot;
using System;

public partial class GrapplingHook : RigidBody2D
{
    public GrapplingGun GrapplingGun { get; set; }

    private IHookable hookedObejct = null;
 
    public void _on_body_entered(Node2D body)
    {
        if (body is IHookable hookable)
        {
            hookedObejct = hookable;
            hookable.Hook(this);
            Hook();
        } else
        {
            UnHook();
        }
    }

    private void ReleaseObject()
    {
        if (hookedObejct is IHookable hookable)
        {
            hookable.UnHook();
        }
    }
    
    public void UnHook()
    {
        ReleaseObject();
        GrapplingGun.ReleaseHook();
    }

    public void Hook()
    {
        GrapplingGun.Hooked();
        LinearVelocity = Vector2.Zero;
        SetDeferred("freeze", true);
    }
}
