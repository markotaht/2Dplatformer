using Godot;
using System;

public partial class AimAtPLayer : Action
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        Vector2 playerPos = (Vector2)board.Get("PlayerPos");
        Enemy enemy = (Enemy)actor;
        enemy.LookAtPosition(playerPos);
        return Status.SUCCESS;
    }
}
