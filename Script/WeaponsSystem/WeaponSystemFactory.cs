using Godot;
using System;

namespace Game.WeaponSystem
{
    public partial class WeaponSystemFactory
    {
        public static IWeaponsSystem CreateWeaponSystem(WeaponData[] weaponData, WeaponsView view, WeaponSystemEvents weaponSystemEvents)
        {
            if(view == null)
            {
                throw new ArgumentNullException("weaponsystem view cannot be null");
            }

            IWeaponsSystem weaponSystem = new WeaponSystem
            {
                weaponSystemEvents = weaponSystemEvents
            };
            weaponSystem.WeaponsChanged += view.UpdateWeaponSlots;
            weaponSystem.WeaponChanged += view.SetActive;

            weaponSystem.Initialize(weaponData);
            return weaponSystem;
        }
    }
}
