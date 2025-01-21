using Godot;
using System;
using System.Collections.Generic;

namespace Game.WeaponSystem
{
    public partial class WeaponSystem : IWeaponsSystem
    {
        private int currentlyEquipped = 0;

        public override void Add(WeaponData weapon)
        {
            Weapons.Add(weapon);
            WeaponsChanged(Weapons);
        }

        public override void Equip(int index)
        {
            currentlyEquipped = index;
            WeaponChanged(currentlyEquipped);
            weaponSystemEvents.EmitSignal(WeaponSystemEvents.SignalName.EquipWeapon, Weapons[currentlyEquipped]);
        }

        public override void EquipFirst()
        {
            currentlyEquipped = 0;
            WeaponChanged(currentlyEquipped);
            weaponSystemEvents.EmitSignal(WeaponSystemEvents.SignalName.EquipWeapon, Weapons[currentlyEquipped]);
        }

        public override void EquipNext()
        {
            currentlyEquipped = ++currentlyEquipped % Weapons.Count;
            WeaponChanged(currentlyEquipped);
            weaponSystemEvents.EmitSignal(WeaponSystemEvents.SignalName.EquipWeapon, Weapons[currentlyEquipped]);
        }

        public override void EquipPrevious()
        {
            currentlyEquipped = mod(--currentlyEquipped ,Weapons.Count);
            WeaponChanged(currentlyEquipped);
            weaponSystemEvents.EmitSignal(WeaponSystemEvents.SignalName.EquipWeapon, Weapons[currentlyEquipped]);
        }

        public override void Remove(WeaponData weapon)
        {
            Weapons.Remove(weapon);
            WeaponsChanged(Weapons);
        }

        int mod(int x, int m) => (x % m) switch
        {
            < 0 and var r => r + m,
            var r => r
        };

        protected override void _initialize(WeaponData[] weaponData)
        {
            Weapons.AddRange(weaponData);
            WeaponsChanged(Weapons);
        }
    }
}
