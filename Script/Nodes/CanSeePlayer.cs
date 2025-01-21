using Godot;
using Godot.Collections;
using System;

public partial class CanSeePlayer : Condition
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        Node2D actor2D = actor as Node2D;
        Vector2 watchDir = (Vector2)board.Get("WatchDir", Vector2.Right);
        Vector2 playerPos = (Vector2)board.Get("PlayerPos");
        if((playerPos - actor2D.GlobalPosition).X * watchDir.X < 0)
        {
            return Status.FAILURE;
        }

        PhysicsDirectSpaceState2D spaceState = actor2D.GetWorld2D().DirectSpaceState;
        PhysicsRayQueryParameters2D query = PhysicsRayQueryParameters2D.Create(actor2D.GlobalPosition, playerPos, 1 + 2 + 4);
        Dictionary colllisions = spaceState.IntersectRay(query);
       
        if (colllisions.Count > 0)
        {
            if ((Node2D)(colllisions["collider"]) is Player player)
            {
                board.Set("CanSeePlayer", true);
                return Status.SUCCESS;
            }
        }

        return Status.FAILURE;
    }
}
