using Godot;
using System;

public partial class EnemyReturnState : EnemyState {
    private Vector3 _destination;

    public override void _Ready() {
        base._Ready();
        Vector3 localPosition = CharacterNode.PathNode.Curve.GetPointPosition(0);
        Vector3 globalPos = CharacterNode.PathNode.GlobalPosition;
        _destination = localPosition + globalPos;
    }
    
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        CharacterNode.GlobalPosition = _destination;
    }
}
