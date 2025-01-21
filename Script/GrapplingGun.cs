using Godot;
using System;

public partial class GrapplingGun : Node2D
{
    [Export]
    public PlayerData PlayerData { get; set; }
    [Export]
    private PackedScene GrapplingHookScene { get; set; }

    [Export]
    private PackedScene GrapplingChainScene { get; set; }

    [Export]
    private Node2D HookSpawn { get; set; }

    private GrapplingHook hook;
    private TextureRect chain;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (hook != null)
        {
            Vector2 dir = hook.GlobalPosition - HookSpawn.GlobalPosition;
            chain.GlobalPosition = hook.GlobalPosition - new Vector2(21, -14.5f).Rotated(dir.Angle());
            chain.Rotation = dir.Angle() + Mathf.Pi;
            chain.SetSize(new Vector2(dir.Length() - 21, chain.Size.Y));
        }

        Vector2 mousePos = GetGlobalMousePosition();

        Rotation = (mousePos - GlobalPosition).Angle();
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed("hook") && hook == null)
        {
            hook = GrapplingHookScene.Instantiate<GrapplingHook>();
            Vector2 dir = (GetGlobalMousePosition() - GlobalPosition).Normalized();
            hook.ApplyCentralImpulse(dir * 1000);
            hook.Position = HookSpawn.GlobalPosition;
            hook.Rotation = dir.Angle();
            hook.GrapplingGun = this;
            GetTree().CurrentScene.AddChild(hook);

            chain = GrapplingChainScene.Instantiate<TextureRect>();
            chain.GlobalPosition = hook.GlobalPosition - new Vector2(21, -14.5f).Rotated(dir.Angle());
            chain.Rotation = dir.Angle() + +Mathf.Pi;
            GetTree().CurrentScene.AddChild(chain);
        }
        else if((Input.IsActionJustPressed("hook") || Input.IsActionJustPressed("ui_jump")) && hook != null)
        {
            ReleaseHook();
        }
    }

    public void ReleaseHook()
    {
        if (hook != null)
        {
            hook.QueueFree();
            hook = null;
            chain.QueueFree();
            chain = null;
            PlayerData.Hooked = false;
        }
    }

    public void Hooked()
    {
        PlayerData.Hooked = true;
        PlayerData.HookPoint = hook.GlobalPosition;
    }
}
