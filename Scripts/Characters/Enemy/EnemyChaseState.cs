using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState {
    private CharacterBody3D _target;
    [Export] private Timer _timerNode; 
    
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        _target = CharacterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        _timerNode.Timeout += HandleTimeout;
        
        CharacterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        CharacterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }

    protected override void ExitState() {
        _timerNode.Timeout -= HandleTimeout;
        
        CharacterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        CharacterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }

    public override void _PhysicsProcess(double delta) {
        Move();
    }
    
    private void HandleTimeout() {
        Destination = _target.GlobalPosition;
        CharacterNode.AgentNode.TargetPosition = Destination;
    }
    
    private void HandleAttackAreaBodyEntered(Node3D body) {
        CharacterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }
    
    private void HandleChaseAreaBodyExited(Node3D body) {
        CharacterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
