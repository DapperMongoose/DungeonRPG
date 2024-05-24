using Godot;
using System;

public partial class Player : Character {
    public override void _Ready() {
        base._Ready();
        GameEvents.OnReward += HandleReward;
    }

    public override void _Input(InputEvent @event) {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward
            );
    }
    
    
    private void HandleReward(RewardResource resource) {
        StatResource targetStat = GetStatResource(resource.TargetStat);
        targetStat.StatValue += resource.Amount;
    }
}
