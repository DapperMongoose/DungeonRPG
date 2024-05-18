using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerIdleState : Node {
    public override void _Ready() {
        Player characterNode = GetOwner<Player>();
        characterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
    }
}
