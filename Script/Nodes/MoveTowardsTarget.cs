using Godot;
using Godot.Collections;
using System;

public partial class MoveTowardsTarget : Action
{
    // Called when the node enters the scene tree for the first time.
    public override Status Tick(Node actor, BlackBoard board)
    {
        if (!board.Has("Patrol")) return Status.FAILURE;
        float walkSpeed = (float)board.Get("WalkSpeed");
        Vector2 currentTarget = (Vector2)board.Get("CurrentTarget");

        Vector2 agentPos = (actor as Node2D).GlobalPosition;

        Vector2 dir = (currentTarget - agentPos).Normalized();
        board.Set("WatchDir", dir);
        (actor as Enemy).Move(dir * walkSpeed);
        return Status.SUCCESS;
    }
}
