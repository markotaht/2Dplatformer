using Godot;
using System;

public partial class WoodDoor : Interactable
{

	[Export]
	private TextureRect DoorOpen { get; set; }

	[Export]
	private TextureRect DoorClose { get; set; }

	private bool open = false;

	public override void Interact()
	{
		open = !open;
        DoorClose.Visible = !open;
        DoorClose.ProcessMode = !open ? ProcessModeEnum.Inherit : ProcessModeEnum.Disabled;

        DoorOpen.Visible = open;
		DoorOpen.ProcessMode = open ? ProcessModeEnum.Inherit : ProcessModeEnum.Disabled;
	}
}
