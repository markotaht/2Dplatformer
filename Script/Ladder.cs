using Godot;
using System;

public partial class Ladder : Area2D
{

    private Global global;

    public override void _Ready()
    {
        global = GetNode<Global>("/root/Global");
    }
    public void _on_body_entered(Node2D body)
    {
        if (body is Player)
        {
            global.IsClimbing = true;
        }
    }

    public void _on_body_exited(Node2D body)
    {
        if (body is Player)
        {
            global.IsClimbing = false;
        }
    }
}
