using Godot;
using System;
using System.Linq;

[GlobalClass, Icon("res://Script/behaviourtree/icons/sequencer.svg")]
public partial class Sequence : Composite
{
    // Called when the node enters the scene tree for the first time.
    public override Status Tick(Node actor, BlackBoard board)
    {
        foreach (Node node in GetChildren())
        {
            BehaviourTreeNode btNode = node as BehaviourTreeNode;
            Status res = btNode.Tick(actor, board);
            if (res != Status.SUCCESS)
            {
                return res;
            }
        }
        return Status.SUCCESS;
    }
}
