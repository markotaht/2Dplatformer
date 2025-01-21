using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/succeed.svg")]
public partial class Succeeder : Decorator
{
    // Called when the node enters the scene tree for the first time.
    public override Status Tick(Node actor, BlackBoard board)
    {
        foreach (BehaviourTreeNode node in GetChildren())
        {
            Status res = node.Tick(actor, board);
            if (res == Status.RUNNING)
            {
                return Status.RUNNING;
            }
        }
        return Status.SUCCESS;
    }
}
