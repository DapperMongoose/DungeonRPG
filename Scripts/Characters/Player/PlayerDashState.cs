using Godot;
using System;

public partial class PlayerDashState : PlayerState {
    [Export] private Timer _dashTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float _speed = 10;
    [Export] private PackedScene _bombScene;
    [Export] private Timer _cooldownTimerNode;

    public override void _Ready() {
        base._Ready();
        _dashTimerNode.Timeout += HandleDashTimeout;
        CanTransition = () => _cooldownTimerNode.IsStopped();
    }
    
    public override void _PhysicsProcess(double delta) {
        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }

    private void HandleDashTimeout() {
        _cooldownTimerNode.Start();
        CharacterNode.Velocity = Vector3.Zero;
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimDash);
        
        CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X, 0, CharacterNode.Direction.Y);

        if (CharacterNode.Velocity == Vector3.Zero) {
            CharacterNode.Velocity = CharacterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;
        }
        
        CharacterNode.Velocity *= _speed;
        _dashTimerNode.Start();

        Node3D bomb = _bombScene.Instantiate<Node3D>();
        GetTree().CurrentScene.AddChild(bomb);
        bomb.GlobalPosition = CharacterNode.GlobalPosition;
    }
}
