using Godot;
using System;

public partial class Camera : Camera3D {
    [Export] private Node _target;
    [Export] private Vector3 _positionFromTarget;
    
    public override void _Ready() {
        GameEvents.OnStartGame += HandleOnStartGame;
    }

    private void HandleOnStartGame() {
        Reparent(_target);
        Position = _positionFromTarget;
    }
}
