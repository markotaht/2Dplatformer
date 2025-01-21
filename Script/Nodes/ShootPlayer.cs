using Godot;
using System;

public partial class ShootPlayer : Action
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        Enemy enemy = (Enemy)actor;
        enemy.Shoot();
        board.Set("weaponCooldown", 1);
        return Status.SUCCESS;
    }
}
