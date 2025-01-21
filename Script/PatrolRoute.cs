using Godot;
using Godot.Collections;
using System;

public partial class PatrolRoute : Resource
{
    [Export]
    public Array<Node2D> Nodes { get; set; }
}
