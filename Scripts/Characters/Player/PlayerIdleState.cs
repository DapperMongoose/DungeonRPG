using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerIdleState : Node {

    public override void _Notification(int what) {
        base._Notification(what);
        
        if (what == 5001) {
            Player characterNode = GetOwner<Player>();
            characterNode.AnimPlayerNode.Play(GameConstants.AnimIdle);
        }
    }
}
