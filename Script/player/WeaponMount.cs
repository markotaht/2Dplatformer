using Game.WeaponSystem;
using Godot;
using System;

public partial class WeaponMount : Node2D
{
    private WeaponSystemEvents events;

    public override void _Ready()
    {
        events = GetNode<WeaponSystemEvents>("/root/WeaponSystemEvents");
        events.EquipWeapon += EquipWeapon;
    }

    private void EquipWeapon(WeaponData weaponData)
    {
        foreach(Node child in GetChildren()) 
        {
            RemoveChild(child);
            child.QueueFree();
        }
        Weapon weapon = weaponData.weaponScene.Instantiate<Weapon>();
        weapon.EnemyGun = false;
        AddChild(weapon);
    }
}
