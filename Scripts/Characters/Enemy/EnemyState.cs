using Godot;

public abstract partial class EnemyState : CharacterState {
    protected Vector3 Destination;

    protected Vector3 GetPointGlobalPosition(int index) {
        Vector3 localPosition = CharacterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPos = CharacterNode.PathNode.GlobalPosition;
        return localPosition + globalPos;
    }

    protected void Move() {
        CharacterNode.Flip();
        CharacterNode.Velocity = CharacterNode.GlobalPosition.DirectionTo(Destination);
        CharacterNode.MoveAndSlide();
    }
}
