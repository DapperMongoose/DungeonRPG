using Godot;

public abstract partial class PlayerState : CharacterState {

    public override void _Ready() {
        base._Ready();
        CharacterNode.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }


    protected void CheckForAttackInput() {
        if (Input.IsActionPressed(GameConstants.InputAttack)) {
            CharacterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }
    
    private void HandleZeroHealth() {
        CharacterNode.StateMachineNode.SwitchState<PlayerDeathState>();
    }
}
