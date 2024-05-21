using Godot;
using System;

public partial class EnemyIdleState : EnemyState {

    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
    }
    
}