using Godot;
using System;

public partial class Bomb : Ability {
    public override void _Ready() {
        PlayerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animName) {
        if (animName == GameConstants.AnimExpand) {
            PlayerNode.Play(GameConstants.AnimExplosion);
        } else {
            QueueFree();
        }
    }
}
