using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/action.svg")]
public partial class BehaviourTreeNode : BehaviourTree
{
    public enum Status
    {
        SUCCESS, FAILURE, RUNNING
    }

    public virtual Status Tick(Node actor, BlackBoard board)
    {
        return Status.SUCCESS;
    }
}
