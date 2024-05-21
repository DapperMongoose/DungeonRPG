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

        CharacterNode.AgentNode.TargetPosition = _destination;
    }

    public override void _PhysicsProcess(double delta) {
        CharacterNode.Flip();
        if (CharacterNode.AgentNode.IsNavigationFinished()) {
            GD.Print("Reached Destination");
            return;
        }
        CharacterNode.Velocity = CharacterNode.GlobalPosition.DirectionTo(_destination);
        CharacterNode.MoveAndSlide();
    }
}
