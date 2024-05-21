using Godot;

public abstract partial class PlayerState : CharacterState {

    protected void CheckForAttackInput() {
        if (Input.IsActionPressed(GameConstants.InputAttack)) {
            CharacterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }
    
}
