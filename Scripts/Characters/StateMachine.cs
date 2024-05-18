using Godot;
using System;

public partial class StateMachine : Node {
    [Export] private Node _currentState;
    [Export] private Node[] _states;

    public override void _Ready() {
        _currentState.Notification(5001);
    }
}
