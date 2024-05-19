using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerDashState : Node {
    private Player _characterNode;
    [Export] private Timer _dashTimerNode;

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
            _dashTimerNode.Start();
        } else if (what == 5002) {
            SetPhysicsProcess(false);
        }
    }

    private void HandleDashTimeout() {
        _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}
