using Godot;
using System;

public partial class Player : Character {
    
    public override void _Input(InputEvent @event) {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward
            );
    }

}
