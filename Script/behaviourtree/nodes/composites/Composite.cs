using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/category_composite.svg")]
public partial class Composite : BehaviourTreeNode
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(GetChildCount() < 1)
		{
			GD.Print("BehaviorTree Error: Composite ", Name ," should have at least one child");
		}
	}
}
