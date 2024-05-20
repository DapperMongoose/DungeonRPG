using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public abstract partial class PlayerState : Node {
    protected global::Player CharacterNode;
    public override void _Ready() {
        CharacterNode = GetOwner<global::Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }
    
    public override void _Notification(int what) {
        base._Notification(what);
        
        if (what == 5001) {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        } else if (what == 5002) {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    protected virtual void EnterState() {
    }
}
