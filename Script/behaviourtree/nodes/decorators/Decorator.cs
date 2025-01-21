using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/category_decorator.svg")]
public partial class Decorator : BehaviourTreeNode
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if (GetChildCount() != 1)
        {
            GD.Print("BehaviorTree Error: Devcorator ", Name, " should have one child");
        }
    }
}
