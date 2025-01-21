using Godot;
using System;

namespace Game.WeaponSystem
{
    public partial class WeaponSlot : TextureRect
    {
        [Export]
        private TextureRect WeaponIcon;

        [Export]
        private TextureRect ActiveIcon;

        public void SetActive(bool active)
        {
            ActiveIcon.Visible = active;
        }

        public void UpdateWeaponIcon(Texture2D tex)
        {
            WeaponIcon.Texture = tex;
        }
    }
}
