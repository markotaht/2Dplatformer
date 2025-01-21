using Godot;
using System;

public partial class EnemyBullet : BulletBase
{
    // Called when the node enters the scene tree for the first time.
    public void _on_body_entered(Node2D body)
    {
        if (body is Player player)
        {
            Utility.GetFirstNode<HealthController>(player).TakeDamage();
        }
        QueueFree();
    }
}
