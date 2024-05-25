using Godot;
using System;

public partial class Bomb : Node3D {
    [Export] private AnimationPlayer _playerNode;
    [Export] public float Damage{ get; private set; } = 10;

    public override void _Ready() {
        _playerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animName) {
        if (animName == GameConstants.AnimExpand) {
            _playerNode.Play(GameConstants.AnimExplosion);
        } else {
            QueueFree();
        }
    }
}
