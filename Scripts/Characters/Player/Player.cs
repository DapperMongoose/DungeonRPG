using Godot;
using System;
using DungeonRPG.Scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode {get; private set;}
    [Export] public Sprite3D SpriteNode {get; private set;}
    [Export] public StateMachine StateMachineNode {get; private set;}
    
    public Vector2 Direction;
    
    public override void _Input(InputEvent @event) {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward
            );
    }

    public void Flip() {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) {
            return;
        }
        
        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }
}
