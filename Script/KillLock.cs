using Godot;

public partial class KillLock : Area2D
{
	private int health = 3;

    private Texture2D Hearth_Full = ResourceLoader.Load("res://sprites/hud_heartFull.png") as Texture2D;
    private Texture2D Hearth_Empty = ResourceLoader.Load("res://sprites/hud_heartEmpty.png") as Texture2D;
    // Called when the node enters the scene tree for the first time.

    [Export]
    private DoorController DoorController { get; set; }

    [Export]
    private PackedScene KillLockParticleScene { get; set; }

    [Export]
    private Enemy[] Enemies { get; set; }

    private NinePatchRect NinePatchRect { get; set; }

    public override void _Ready()
    {
        NinePatchRect = GetNode<NinePatchRect>("KillLock");
        foreach(Enemy enemy in Enemies)
        {
            enemy.Died += Killed;
        }
    }

    private void UpdateHealth()
    {
        for (int i = 0; i < NinePatchRect.GetChildCount(); i++)
        {
            if (health > i)
            {
                (NinePatchRect.GetChild(i) as Sprite2D).Texture = Hearth_Full;
            }
            else
            {
                (NinePatchRect.GetChild(i) as Sprite2D).Texture = Hearth_Empty;
            }
        }
    }

    public void Killed(Enemy enemy)
    {
        KillLockParticle particle = KillLockParticleScene.Instantiate<KillLockParticle>();
        particle.End = GlobalPosition;
        particle.Target = this;
        particle.GlobalPosition = enemy.GlobalPosition;
        GetTree().CurrentScene.CallDeferred("add_child", particle);
    }

    public void ReduceHealth()
    {
        --health;
        UpdateHealth();

        if (health == 0)
        {
            DoorController.OpenDoor();
        }
    }
}
