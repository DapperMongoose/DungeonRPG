using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState {
    private Vector3 _targetPosition;
    
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);
        Node3D target = CharacterNode.AttackAreaNode.GetOverlappingBodies().First();
        _targetPosition = target.GlobalPosition;
        CharacterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState() {
        CharacterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void PerformHit() {
        CharacterNode.ToggleHitBox(false);
        CharacterNode.HitBoxNode.GlobalPosition = _targetPosition;
    }
    
    
    private void HandleAnimationFinished(StringName animname) {
        CharacterNode.ToggleHitBox(true);

        Node3D target = CharacterNode.AttackAreaNode.GetOverlappingBodies().FirstOrDefault();

        if (target == null) {
            Node3D chaseTarget = CharacterNode.ChaseAreaNode.GetOverlappingBodies().FirstOrDefault();

            if (chaseTarget == null) {
                CharacterNode.StateMachineNode.SwitchState<EnemyReturnState>();
                return;
            }
            
            CharacterNode.StateMachineNode.SwitchState<EnemyChaseState>();
            return;
        }
        
        Vector3 direction = CharacterNode.GlobalPosition.DirectionTo(_targetPosition);
        CharacterNode.SpriteNode.FlipH = direction.X < 0;
        
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimAttack);
        _targetPosition = target.GlobalPosition;
    }
}
