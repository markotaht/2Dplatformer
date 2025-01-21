using Godot;
using System;

public partial class PlayerData : Resource
{
    [Export]
    public bool Hooked { get; set; }

    [Export]
    public Vector2 HookPoint { get; set; }

    [Export]
    public float Gravity { get; set; } = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    [Export]
    public float Speed { get; set; }  = 300.0f;
    [Export]
    public float JumpVelocity { get; set; } = 600.0f;
}
