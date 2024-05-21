using Godot;
using System;

public partial class EnemyAttackState : EnemyState  {
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);
    }
}
