using Godot;
using Godot.Collections;
using System;

public partial class GetNextTarget : Action
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        if (!board.Has("Patrol")) return Status.FAILURE;
        Array<Node2D> patrolPoints = ((PatrolRoute)board.Get("Patrol")).Nodes;
        int currentTargetIndex = (int)board.Get("CurrentTargetIndex", 0);

        if (!board.Has("CurrentTarget"))
        {
            board.Set("CurrentTarget", patrolPoints[currentTargetIndex].Position);
            return Status.SUCCESS;
        }

        currentTargetIndex = (currentTargetIndex + 1) % patrolPoints.Count;
        board.Set("CurrentTargetIndex", currentTargetIndex);
        board.Set("CurrentTarget", patrolPoints[currentTargetIndex].Position);
        return Status.SUCCESS;
    }
}
