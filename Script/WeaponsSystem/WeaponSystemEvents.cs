using Godot;
using System;

namespace Game.WeaponSystem
{
    public partial class WeaponSystemEvents : Node
    {
        [Signal]
        public delegate void EquipWeaponEventHandler(WeaponData weaponData);
    }
}
