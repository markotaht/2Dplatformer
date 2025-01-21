using Godot;
using System;

public partial class Interactable : Area2D
{

    [Export]
    private KeyPromt KeyPromt { get; set; }

    private InteractableInputHandler inputHandler;

    public override void _Ready()
    {
        inputHandler = GetNode<InteractableInputHandler>("/root/InteractableInputHandler");
    }
    public virtual void Interact()
    {

    }

    public void _on_body_entered(Node2D body)
    {
        if (body is Player)
        {

            inputHandler.RegisterInteractable(this);
            KeyPromt.Visible = true;
        }
    }

    public void _on_body_exited(Node2D body)
    {
        if (body is Player)
        {
            inputHandler.DeRegisterInteractable();
            KeyPromt.Visible = false;
        }
    }
}
