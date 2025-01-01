using Godot;
using System;

public partial class Player : RigidBody2D
{
    [Export] public int JumpHeight = 300;

    [Signal]
    public delegate void HitEventHandler();

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        if (Input.IsActionJustPressed("jump"))
        {
            state.SetLinearVelocity(new Vector2(0, -JumpHeight));
        }
    }

    private void OnBodyEntered(Node2D body)
    {
        CallDeferred("set_freeze_enabled", true);
        EmitSignal(SignalName.Hit);
    }
}
