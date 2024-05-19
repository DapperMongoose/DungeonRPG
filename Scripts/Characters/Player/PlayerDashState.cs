using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerDashState : Node {
    private Player _characterNode;
    [Export] private Timer _dashTimerNode;
    [Export] private float _speed = 10;

    public override void _Ready() {
        _characterNode = GetOwner<Player>();
        _dashTimerNode.Timeout += HandleDashTimeout;
        SetPhysicsProcess(false);
    }
    
    public override void _Notification(int what) {
        base._Notification(what);
        
        if (what == 5001) {
            _characterNode.AnimPlayerNode.Play(GameConstants.AnimDash);
            SetPhysicsProcess(true);
            _characterNode.Velocity = new Vector3(_characterNode.Direction.X, 0, _characterNode.Direction.Y);

            if (_characterNode.Velocity == Vector3.Zero) {
                _characterNode.Velocity = _characterNode.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;
            }
            
            _characterNode.Velocity *= _speed;
            _dashTimerNode.Start();
        } else if (what == 5002) {
            SetPhysicsProcess(false);
        }
    }
    
    public override void _PhysicsProcess(double delta) {
        _characterNode.MoveAndSlide();
        _characterNode.Flip();
    }

    private void HandleDashTimeout() {
        _characterNode.Velocity = Vector3.Zero;
        _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}
