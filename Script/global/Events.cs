using Godot;
using System;

public partial class Events : Node
{
    public static Events Instance { get; private set; }

    [Signal]
    public delegate void UpdateHealthEventHandler(int health);

    public override void _Ready()
    {
        Instance = this;
    }
}
