using Godot;
using System;

public partial class EnemyDeathState : EnemyState {
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimDeath);
        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animname) {
        CharacterNode.PathNode.QueueFree();
    }
}
