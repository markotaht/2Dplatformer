using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/action.svg")]
public partial class Leaf : BehaviourTreeNode
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        if (GetChildCount() != 0)
        {
            GD.Print("BehaviorTree Error: Leaf ", Name, " should not have children");
        }
    }
}
