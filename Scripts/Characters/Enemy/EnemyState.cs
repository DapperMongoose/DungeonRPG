using Godot;

public abstract partial class EnemyState : CharacterState {
    protected Vector3 Destination;

    public override void _Ready() {
        base._Ready();
        CharacterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }
    
    protected Vector3 GetPointGlobalPosition(int index) {
        Vector3 localPosition = CharacterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPos = CharacterNode.PathNode.GlobalPosition;
        return localPosition + globalPos;
    }

    protected void Move() {
        CharacterNode.Flip();
        CharacterNode.AgentNode.GetNextPathPosition();
        CharacterNode.Velocity = CharacterNode.GlobalPosition.DirectionTo(Destination);
        CharacterNode.MoveAndSlide();
    }

    protected void HandleChaseAreaBodyEntered(Node3D body) {
        CharacterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }
    
    private void HandleZeroHealth() {
        CharacterNode.StateMachineNode.SwitchState<EnemyDeathState>();
    }
}
