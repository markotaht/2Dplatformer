using Godot;
using System;

public partial class GetPlayerPosition : Action
{
    private Player _player;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        _player = GetNode<Player>("/root/Node2D/Player");
    }

    public override Status Tick(Node actor, BlackBoard board)
    {
        board.Set("PlayerPos", _player.GlobalPosition);
        return Status.SUCCESS;
    }
}
