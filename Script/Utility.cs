using Godot;
using System;
using System.Linq;

public static class Utility
{
    public static T GetFirstNode<T>(this Node node) where T : Node
    {
        return node.GetChildren().OfType<T>().FirstOrDefault();
    }
}
