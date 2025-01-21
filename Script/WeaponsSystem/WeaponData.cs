using Godot;
using System;

namespace Game.WeaponSystem
{
    [GlobalClass]
    public partial class WeaponData : Resource
    {
        [Export]
        public Texture2D Icon;

        [Export]
        public PackedScene weaponScene;
    }
}
