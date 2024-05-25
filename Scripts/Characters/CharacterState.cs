using Godot;
using System;

public abstract partial class CharacterState : Node {
    protected Character CharacterNode;
    public Func<bool> CanTransition = () => true;
    
    public override void _Ready() {
        CharacterNode = GetOwner<Character>();
        
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }
    
    public override void _Notification(int what) {
        base._Notification(what);
        
        if (what == GameConstants.NotificationEnterState) {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        } else if (what == GameConstants.NotificationExitState) {
            ExitState();
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    protected virtual void EnterState() {
    }

    protected virtual void ExitState() {
    }
}
