using Godot;
using System;

[GlobalClass]
public partial class Debug : Decorator
{
    public override Status Tick(Node actor, BlackBoard board)
    {
        BehaviourTreeNode node = (BehaviourTreeNode)GetChildren()[0];
        Status res = node.Tick(actor, board);
        GD.Print("Node ", node.Name, " result is ", res);
        return res;
    }
}
