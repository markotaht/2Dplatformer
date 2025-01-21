using Godot;
using System;
using System.Collections.Generic;

namespace Game.WeaponSystem
{
    public partial class WeaponsView : Control
    {
        [Export]
        private WeaponSlot[] weaponSlots;

        public void UpdateWeaponSlots(List<WeaponData> weapons)
        {
            for (int i = 0; i < weaponSlots.Length; i++)
            {
                if (i < weapons.Count)
                {
                    weaponSlots[i].UpdateWeaponIcon(weapons[i].Icon);
                }
                else
                {
                    weaponSlots[i].ProcessMode = ProcessModeEnum.Disabled;
                }
            }
        }

        public void SetActive(int index)
        {
            for (int i = 0; i < weaponSlots.Length; i++)
            {
                weaponSlots[i].SetActive(i == index);
            }
        }
    }
}