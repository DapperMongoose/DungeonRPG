using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState {
    private Vector3 _targetPosition;
    
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);
        Node3D target = CharacterNode.AttackAreaNode.GetOverlappingBodies().First();
        _targetPosition = target.GlobalPosition;
    }

    protected override void ExitState() {
        CharacterNode.ToggleHitBox(true);
    }

    private void PerformHit() {
        CharacterNode.ToggleHitBox(false);
        CharacterNode.HitBoxNode.GlobalPosition = _targetPosition;
        
    }
}
