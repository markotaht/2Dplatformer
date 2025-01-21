using Godot;
using System;
using System.Collections.Generic;

namespace Game.WeaponSystem
{
    public delegate void WeaponsChanged(List<WeaponData> weapons);
    public delegate void WeaponChanged(int index);
    public abstract class IWeaponsSystem
    {
        public List<WeaponData> Weapons { get; } = new List<WeaponData>();
        public WeaponChanged WeaponChanged { get; set; }
        public WeaponsChanged WeaponsChanged { get; set; }
        public WeaponSystemEvents weaponSystemEvents { get; set; }
        public void Initialize(WeaponData[] weaponData)
        {
            WeaponSystemInputHandler.Instance.RegisterWeaponSystem(this);
            _initialize(weaponData);
        }

        protected virtual void _initialize(WeaponData[] weaponData)
        {

        }

        public virtual void Destroy()
        {
            WeaponSystemInputHandler.Instance.UnRegisterWeaponSystem();
        }
        public virtual void Add(WeaponData weapon) { }
        public virtual void Remove(WeaponData weapon) { }
        public virtual void EquipNext() { }
        public virtual void EquipPrevious() { }
        public virtual void Equip(int index) { }
        public virtual void EquipFirst() { }
        public virtual void Update(double delta) { }
    }
}
