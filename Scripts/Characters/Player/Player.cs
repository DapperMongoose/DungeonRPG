using Godot;
using System;
using DungeonRPG.Scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer _animPlayerNode;
    [Export] private Sprite3D _spriteNode;
    
    private Vector2 _direction;

    public override void _Ready() {
        _animPlayerNode.Play(GameConstants.AnimIdle);
    }
    
    public override void _PhysicsProcess(double delta) {
        Velocity = new Vector3(_direction.X, 0, _direction.Y);
        Velocity *= 5;
        
        MoveAndSlide();
        Flip();
    }
    
    public override void _Input(InputEvent @event) {
        _direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward
            );

        if (_direction == Vector2.Zero) {
            _animPlayerNode.Play(GameConstants.AnimIdle);
        }
        else {
            _animPlayerNode.Play(GameConstants.AnimMove);
        }
    }

    private void Flip() {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) {
            return;
        }
        
        bool isMovingLeft = Velocity.X < 0;
        _spriteNode.FlipH = isMovingLeft;
    }
}
