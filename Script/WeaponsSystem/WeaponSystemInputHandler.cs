using Godot;
using System;

namespace Game.WeaponSystem
{
    public partial class WeaponSystemInputHandler : Node
    {
        public static WeaponSystemInputHandler Instance { get; private set; }

        [Signal]
        public delegate void WeaponChangedEventHandler(Weapon weapon);

        private IWeaponsSystem _weaponSystem;
        private Weapon _weapon;

        public override void _Ready()
        {
            Instance = this;
        }

        public override void _Process(double delta)
        {
            if (Input.IsActionJustPressed("fire"))
            {
                _weapon.Attack();
            }
            if (Input.IsActionJustPressed("weapons_left"))
            {
                _weaponSystem.EquipPrevious();
            }

            if (Input.IsActionJustPressed("weapons_right"))
            {
                _weaponSystem.EquipNext();
            }
        }

        public void RegisterWeaponSystem(IWeaponsSystem weaponSystem)
        {
            _weaponSystem = weaponSystem;
        }

        public void UnRegisterWeaponSystem()
        {
            _weaponSystem = null;
        }

        public void RegisterWeapon(Weapon weapon)
        {
            _weapon = weapon;
            EmitSignal(SignalName.WeaponChanged, weapon);
        }

        public void UnRegisterWeapon()
        {
            _weapon = null;
            EmitSignal(SignalName.WeaponChanged, _weapon);
        }
    }
}
