using Godot;
using System;
using System.Runtime.CompilerServices;

[GlobalClass, Icon("res://Script/behaviourtree/icons/limiter.svg")]
public partial class Limiter : Decorator
{
    [Export]
    private float max_count = 0;

    private String cacheKey;

    public override void _Ready()
    {
        base._Ready();
        cacheKey = "limiter_" + GetInstanceId();
    }
    public override Status Tick(Node actor, BlackBoard board)
    {
        float currentCount = (float)board.Get(cacheKey, 0f);

        if(currentCount <= max_count) { 
            board.Set(cacheKey, currentCount + 1);
            return (GetChild(0) as BehaviourTreeNode).Tick(actor, board);
        } else
        {
            return Status.FAILURE;
        }
    }
}
