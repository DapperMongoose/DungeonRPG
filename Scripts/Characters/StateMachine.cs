using Godot;
using System;

public partial class StateMachine : Node {
    [Export] private Node _currentState;
    [Export] private CharacterState[] _states;

    public override void _Ready() {
        _currentState.Notification(GameConstants.NotificationEnterState);
    }

    public void SwitchState<T>() {
        CharacterState newState = null;

        foreach (CharacterState state in _states) {
            if (state is T) {
                newState = state;
                break;
            }
        }

        if (newState == null) {
            return;
        }

        if (_currentState is T) {
            return;
        }

        if (!newState.CanTransition()) {
            return;
        }

        _currentState.Notification(GameConstants.NotificationExitState);
        _currentState = newState;
        _currentState.Notification(GameConstants.NotificationEnterState);

    }
}
