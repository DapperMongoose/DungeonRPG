using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerMoveState : Node {
    public override void _Ready() {
        Player characterNode = GetOwner<Player>();
        characterNode.AnimPlayerNode.Play(GameConstants.AnimMove);
    }
}
