using Godot;
using System;

public partial class InteractableInputHandler : Node
{
    private Interactable interactable;

    public void RegisterInteractable(Interactable interactable)
    {
        this.interactable = interactable;
    }

    public void DeRegisterInteractable()
    {
        this.interactable = null;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("interact") && interactable != null)
        {
            interactable.Interact();
        }
    }
}
