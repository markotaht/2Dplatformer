using Godot;
using System;

public interface IHookable
{
    GrapplingHook HookObject { get; set; }
    void Hook(GrapplingHook hook);
    void UnHook();
}
