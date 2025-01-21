using Godot;
using System;

public partial class Gun : Weapon
{

    [Export]
    public PackedScene BulletScene { get; set; }

    [Export]
    public Node2D BulletSpawn { get; set; }

    //TODO extract to aimController. Create LookAt Function
    protected override void _AimAt(Vector2 position)
    {
        GlobalRotation = (position - GlobalPosition).Angle();
    }

    protected override void _attack()
    {
        BulletBase bullet = BulletScene.Instantiate<BulletBase>();
        Vector2 dir = (GetGlobalMousePosition() - GlobalPosition).Normalized();
        bullet.ApplyCentralImpulse(dir * 1000);
        bullet.Position = BulletSpawn.GlobalPosition;
        GetTree().CurrentScene.AddChild(bullet);
    }

    public override void Holster()
    {
        Position = new Vector2(0, -10);
        RotationDegrees = 90;
        Holstered =true;
    }

    public override void UnHolster()
    {
        Position = new Vector2(0, 0);
        Rotation = 0;
        Holstered = false;
    }
}
