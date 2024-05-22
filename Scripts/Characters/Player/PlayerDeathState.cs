using Godot;
using System;

public partial class PlayerDeathState : PlayerState {
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimDeath);
        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animname) {
        CharacterNode.QueueFree();
    }
}
