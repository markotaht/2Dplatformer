using Godot;
using System;

public partial class LookAtMouse : Sprite2D
{
	public override void _Process(double delta)
	{
        var (x, _) = GetGlobalMousePosition();
        Vector2 sclale = ((Node2D)GetParent()).Scale;
        if (x < GlobalPosition.X)
        {
            sclale.X = -1;
        }
        else
        {
            sclale.X = 1;
        }
        ((Node2D)GetParent()).Scale = sclale;
    }
}
