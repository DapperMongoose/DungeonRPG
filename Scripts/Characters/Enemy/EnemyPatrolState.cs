using Godot;
using System;

public partial class EnemyPatrolState : EnemyState {
    private int _pointIndex = 0;

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);

        _pointIndex = 1;

        Destination = GetPointGlobalPosition(_pointIndex);
        CharacterNode.AgentNode.TargetPosition = Destination;

        CharacterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
    }

    public override void _PhysicsProcess(double delta) {
        Move();
    }
    
    private void HandleNavigationFinished() {
        _pointIndex = Mathf.Wrap(_pointIndex + 1, 0, CharacterNode.PathNode.Curve.PointCount);

        Destination = GetPointGlobalPosition(_pointIndex);
        CharacterNode.AgentNode.TargetPosition = Destination;
    }
}
