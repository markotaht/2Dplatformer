using Godot;

public partial class HealthController : Node
{ 
    private int currentHealth = 10;
    private Events events;
    public override void _Ready()
    {
        events = GetNode<Events>("/root/Events");
        events.EmitSignal(Events.SignalName.UpdateHealth, currentHealth);
    }

    public void TakeDamage()
    {
        events.EmitSignal(Events.SignalName.UpdateHealth, --currentHealth);
    }
}
