using Godot;
using System;
using DungeonRPG.Scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode;
    [Export] public Sprite3D SpriteNode;
    [Export] public StateMachine StateMachineNode;
    
    public Vector2 Direction;
    
    public override void _PhysicsProcess(double delta) {
        Velocity = new Vector3(Direction.X, 0, Direction.Y);
        Velocity *= 5;
        
        MoveAndSlide();
        Flip();
    }
    
    public override void _Input(InputEvent @event) {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward
            );
    }

    private void Flip() {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) {
            return;
        }
        
        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }
}
