using Godot;
using System;

[GlobalClass, Icon("res://Script/behaviourtree/icons/tree.svg")]
public partial class BehaviourTreeRoot : BehaviourTree
{

    [Export]
    public BlackBoard BlackBoard { get; set; } = new BlackBoard();

	bool enabled = true;

    public override void _Ready()
    {
        if(GetChildCount() != 1)
        {
            GD.Print("Behavior Tree error: Root should have one child");
            Disable();
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if(!enabled)
        {
            return;
        }

        BlackBoard.Set("delta", delta);
        (GetChild(0) as BehaviourTreeNode).Tick(GetParent(), BlackBoard);
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}
