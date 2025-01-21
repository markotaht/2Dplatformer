using Godot;

public partial class HealthBar : HBoxContainer
{
	private Texture2D Hearth_Full = ResourceLoader.Load("res://sprites/hud_heartFull.png") as Texture2D;
	private Texture2D Hearth_Empty = ResourceLoader.Load("res://sprites/hud_heartEmpty.png") as Texture2D;
	private Texture2D Hearth_Half = ResourceLoader.Load("res://sprites/hud_heartHalf.png") as Texture2D;


    private Events events;

    public override void _Ready()
    { 
        events = GetNode<Events>("/root/Events");
        events.UpdateHealth += UpdateHealth;
    }

    public override void _ExitTree()
    {
        events.UpdateHealth -= UpdateHealth;
    }

    public void UpdateHealth(int value)
	{
		for(int i = 0; i < GetChildCount(); i++)
		{
			if(value > i *2 + 1)
			{
				(GetChild(i) as TextureRect).Texture = Hearth_Full;
			} else if(value > i * 2)
			{
                (GetChild(i) as TextureRect).Texture = Hearth_Half;
            } else
			{
                (GetChild(i) as TextureRect).Texture = Hearth_Empty;
            }
		}
	}
}
