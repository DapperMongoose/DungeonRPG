using Godot;
using System;

public partial class EnemyPatrolState : EnemyState {

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);

        Destination = GetPointGlobalPosition(1);
        CharacterNode.AgentNode.TargetPosition = Destination;
    }

    public override void _PhysicsProcess(double delta) {
        Move();
    }
}
