using Godot;
using System;

public partial class Sword : Weapon
{
	private AnimatedSprite2D _sprite;
    private bool attack = false;
    private double currentTime = 0;
    private double attackTime = 0.2;
    private bool holstered = true;

    [Export]
    private Node CollisionArea { get; set; }
	// Called when the node enters the scene tree for the first time.
	protected override void Initialize()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _sprite.Play("idle");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	protected override void Update(double delta)
	{
        if (attack)
        {
            currentTime = currentTime + delta;
            if(currentTime > attackTime) { 
                attack = false;
                _sprite.Play("idle");
                CollisionArea.ProcessMode = ProcessModeEnum.Disabled;
                currentTime = 0;
            }
        }
    }

    protected override void _attack()
    {
        _sprite.Play("attack");
        CollisionArea.ProcessMode = ProcessModeEnum.Inherit;
        attack = true;
    }

    public override void Holster()
    {
        Position = new Vector2(-16, -16);
        RotationDegrees = 90;
        Holstered = true;
    }

    public override void UnHolster()
    {
        Position = new Vector2(-0, -0);
        Rotation = 0;
        Holstered = false;
    }

    public void _on_area_2d_body_entered(PhysicsBody2D body)
    {
        if (body is Enemy enemy)
        {
            enemy.Die();
            body.QueueFree();
        }
    }
}
