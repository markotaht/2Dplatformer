using Godot;
using System;

public partial class HasCooldownEnded : Action
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        double currentCooldown = (double)board.Get("weaponCooldown", 0.0);
        if (currentCooldown < 0)
        {
            return Status.SUCCESS;
        }
        else
        {
            currentCooldown -= (double)board.Get("delta");
            board.Set("weaponCooldown", currentCooldown);
            return Status.FAILURE;
        }
    }
}
