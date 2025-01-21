using Game.WeaponSystem;
using Godot;
using System;

public partial class Weapon : Node2D
{

    [Export]
    protected Boolean Holstered { get; set; } = true;

    [Export]
    public Boolean EnemyGun { get; set; } = true;

    public override sealed void _Ready()
    {
        if (!EnemyGun)
        {
            WeaponSystemInputHandler.Instance.RegisterWeapon(this);
        }
       Initialize();
    }

    public override sealed void _ExitTree()
    {
        if (!EnemyGun)
        {
            WeaponSystemInputHandler.Instance.UnRegisterWeapon();
        }
        Terminate();
    }

    protected virtual void Initialize() { }

    protected virtual void Terminate() { }

    public void Attack()
    {
        if (Holstered) { return; }
        _attack();
    }
    protected virtual void _attack()
    {

    }

    public virtual void Holster()
    {

    }

    public virtual void UnHolster()
    {

    }

    public override void _Process(double delta)
    {
        if (Holstered) { return; }
        Update(delta);
    }

    protected virtual void Update(double delta) { }

    public void AimAt(Vector2 position)
    {
        if (Holstered) { return; }
        _AimAt(position);
    }

    protected virtual void _AimAt(Vector2 position) { }
}
