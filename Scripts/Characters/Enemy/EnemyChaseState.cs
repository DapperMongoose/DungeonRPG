using Godot;
using System;

public partial class EnemyChaseState : EnemyState {
    protected override void EnterState() {
        CharacterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
        GD.Print("chase state");
    }
}
