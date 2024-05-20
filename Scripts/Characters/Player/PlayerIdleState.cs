using DungeonRPG.Scripts.Characters.Player;
using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerIdleState : PlayerState {
    
    public override void _PhysicsProcess(double delta) {
        if (CharacterNode.Direction != Vector2.Zero) {
            CharacterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }
    
    public override void _Input(InputEvent @event) {
        if (Input.IsActionJustPressed(GameConstants.InputDash)) {
            CharacterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
    }
}
