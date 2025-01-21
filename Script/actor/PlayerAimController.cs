using Game.WeaponSystem;
using Godot;
using System;

public partial class PlayerAimController : Node2D
{
    private Weapon weapon;

    public override void _Ready()
    {
        WeaponSystemInputHandler.Instance.WeaponChanged += WeaponChanged;
    }
    public void WeaponChanged(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public override void _Process(double delta)
    {
        weapon.AimAt(GetGlobalMousePosition());
    }
}
