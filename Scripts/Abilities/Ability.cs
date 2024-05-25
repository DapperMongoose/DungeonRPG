using Godot;

public abstract partial class Ability : Node3D {
    [Export] protected AnimationPlayer PlayerNode;
    [Export] public float Damage{ get; private set; } = 10;
}
