using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/inverter.svg")]
public partial class Inverter : Decorator
{
    // Called when the node enters the scene tree for the first time.
    public override Status Tick(Node actor, BlackBoard board)
    {
        foreach (BehaviourTreeNode node in GetChildren())
        {
            Status res = node.Tick(actor, board);
            if (res == Status.SUCCESS)
            {
                return Status.FAILURE;
            }
            if (res == Status.FAILURE)
            {
                return Status.SUCCESS;
            }
        }
        return Status.RUNNING;
    }
}
