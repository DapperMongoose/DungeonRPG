using Godot;
using System;

public partial class Player : CharacterBody3D {
    private Vector2 _direction = new();
    public override void _PhysicsProcess(double delta) {
        Velocity = new Vector3(_direction.X, 0, _direction.Y);
        Velocity *= 5;

        MoveAndSlide();
    }
    
    public override void _Input(InputEvent @event) {
        _direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
        
    }
}
