using DungeonRPG.Scripts.Characters.Player;
using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerDashState : PlayerState {
    [Export] private Timer _dashTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float _speed = 10;

    public override void _Ready() {
        base._Ready();
        _dashTimerNode.Timeout += HandleDashTimeout;
    }
    
    public override void _PhysicsProcess(double delta) {
        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }

    private void HandleDashTimeout() {
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
    }
}
