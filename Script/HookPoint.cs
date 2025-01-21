using Godot;
using System;

public partial class HookPoint : StaticBody2D, IHookable
{
    public GrapplingHook HookObject { get; set; }

    public void UnHook()
    {
        HookObject = null;
    }

    void IHookable.Hook(GrapplingHook hook)
    {
        HookObject = hook;
    }
}
