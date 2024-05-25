using Godot;
using System;

public partial class EnemyStunState : EnemyState {
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimStun);
        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }
    
    protected override void ExitState() {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animname) {
        if (CharacterNode.AttackAreaNode.HasOverlappingBodies()) {
            CharacterNode.StateMachineNode.SwitchState<EnemyAttackState>();
        } else if (CharacterNode.ChaseAreaNode.HasOverlappingBodies()) {
            CharacterNode.StateMachineNode.SwitchState<EnemyChaseState>();
        } else {
            CharacterNode.StateMachineNode.SwitchState<EnemyIdleState>();
        }
    }
}
