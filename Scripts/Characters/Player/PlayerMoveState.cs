using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerMoveState : Node {
    private Player _characterNode;
    
    public override void _Ready() {
        _characterNode = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta) {
        if (_characterNode.Direction == Vector2.Zero) {
            _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
        }
    }
    
    public override void _Notification(int what) {
        base._Notification(what);
        
        if (what == 5001) {
            Player characterNode = GetOwner<Player>();
            characterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        }
    }
}
