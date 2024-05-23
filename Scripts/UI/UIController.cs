using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class UIController : Control {
    private Dictionary<ContainerType, UIContainer> _containers;

    public override void _Ready() {
        _containers = GetChildren().Where(
            (element) => element is UIContainer
            ).Cast<UIContainer>().ToDictionary(
            (element) => element.Container
            );

        _containers[ContainerType.Start].Visible = true;
        _containers[ContainerType.Start].ButtonNode.Pressed += HandleStartPressed;

        GameEvents.OnEndGame += HandleEndGame;
        GameEvents.OnVictory += HandleVictory;
    }

    private void HandleVictory() {
        _containers[ContainerType.Stats].Visible = false;
        _containers[ContainerType.Victory].Visible = true;
        GetTree().Paused = true;
    }

    private void HandleEndGame() {
        _containers[ContainerType.Stats].Visible = false;
        _containers[ContainerType.Defeat].Visible = true;
    }

    private void HandleStartPressed() {
        GetTree().Paused = false;
        _containers[ContainerType.Start].Visible = false;
        _containers[ContainerType.Stats].Visible = true;
        
        GameEvents.RaiseStartGame();
    }
}
