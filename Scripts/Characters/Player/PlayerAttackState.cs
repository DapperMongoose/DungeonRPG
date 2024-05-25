using Godot;
using System;

public partial class PlayerAttackState : PlayerState {
    [Export] private Timer _comboTimerNode;
    [Export] private PackedScene _lightningScene;

    private int _comboCounter = 1;
    private int _maxComboCount = 2;

    public override void _Ready() {
        base._Ready();
        _comboTimerNode.Timeout += () => _comboCounter = 1;
    }

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack + _comboCounter, -1, 1.5f);
        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
        CharacterNode.HitBoxNode.BodyEntered += HandleBodyEntered;
    }

    protected override void ExitState() {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
        _comboTimerNode.Start();
        CharacterNode.ToggleHitBox(true);
        CharacterNode.HitBoxNode.BodyEntered -= HandleBodyEntered;
    }

    private void HandleAnimationFinished(StringName animname) {
        _comboCounter++;
        _comboCounter = Mathf.Wrap(_comboCounter, 1, _maxComboCount + 1);
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    private void PerformHit() {
        Vector3 newPosition = CharacterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;
        float distanceMultiplier = 0.75f;
        CharacterNode.HitBoxNode.Position = newPosition * distanceMultiplier;
        
        CharacterNode.ToggleHitBox(false);
    }
    
    private void HandleBodyEntered(Node3D body) {
        if (_comboCounter != _maxComboCount) {
            return;
        }

        Node3D lightning = _lightningScene.Instantiate<Node3D>();
        GetTree().CurrentScene.AddChild(lightning);
        lightning.GlobalPosition = body.GlobalPosition;
    }
}
