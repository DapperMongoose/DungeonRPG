using Godot;
using System;

public partial class EnemyIdleState : EnemyState {

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
    }

    public override void _PhysicsProcess(double delta) {
        CharacterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
