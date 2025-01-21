using Godot;
using System;

public partial class Bullet : BulletBase
{
    public void _on_body_entered(Node2D body)
    {
        if (body.IsInGroup("Enemies") && body is Enemy enemy){
            enemy.Die();
            body.QueueFree();
        }
        QueueFree();
    }
}
