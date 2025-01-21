using Godot;
using Godot.Collections;
using System;

public partial class HasReachedTarget : Condition
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        if (!board.Has("Patrol")) return Status.FAILURE;

        if (!board.Has("CurrentTarget"))
        {
            return Status.SUCCESS;
        }
        Vector2 currentTarget = (Vector2)board.Get("CurrentTarget");
        Vector2 agentPos = (actor as Node2D).GlobalPosition;

        if(currentTarget.DistanceTo(agentPos) < 10)
        {
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
