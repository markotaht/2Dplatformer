using Godot;
using System;

namespace Game.WeaponSystem
{
    public partial class WeaponsController: Node
    {
        [Export]
        private WeaponsView view;

        [Export]
        private WeaponData[] weaponData;

        private IWeaponsSystem weaponsSystem;

        public override void _Ready()
        {
            weaponsSystem = WeaponSystemFactory.CreateWeaponSystem(weaponData, view, GetNode<WeaponSystemEvents>("/root/WeaponSystemEvents"));
            weaponsSystem.EquipFirst();
        }

        public override void _Process(double delta)
        {
            weaponsSystem.Update(delta);
        }

        public override void _ExitTree()
        {
            weaponsSystem.Destroy();
        }
    }

}
