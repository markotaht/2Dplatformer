using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/selector.svg")]
public partial class Selector : Composite
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        foreach(BehaviourTreeNode node in GetChildren())
        {
            Status res = node.Tick(actor, board);
            if(res != Status.FAILURE)
            {
                return res;
            }
        }
        return Status.FAILURE;
    }
}
