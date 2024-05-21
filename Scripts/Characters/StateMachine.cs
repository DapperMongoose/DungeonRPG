using Godot;
using System;

public partial class StateMachine : Node {
    [Export] private Node _currentState;
    [Export] private Node[] _states;

    public override void _Ready() {
        _currentState.Notification(GameConstants.NotificationEnterState);
    }

    public void SwitchState<T>() {
        Node newState = null;

        foreach (Node state in _states) {
            if (state is T) {
                newState = state;
                break;
            }
        }

        if (newState == null) {
            return;
        }

        _currentState.Notification(GameConstants.NotificationExitState);
        _currentState = newState;
        _currentState.Notification(GameConstants.NotificationEnterState);

    }
}
