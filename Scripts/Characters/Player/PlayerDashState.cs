using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerDashState : Node {
    private Player _characterNode;

    public override void _Ready() {
        _characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta) {
        if (_characterNode.Direction != Vector2.Zero) {
            _characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }
    
    public override void _Notification(int what) {
        base._Notification(what);
        
        if (what == 5001) {
            _characterNode.AnimPlayerNode.Play(GameConstants.AnimDash);
            SetPhysicsProcess(true);
        } else if (what == 5002) {
            SetPhysicsProcess(false);
        }
    }
}
