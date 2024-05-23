using Godot;
using System;

public partial class StatLabel : Label {
    [Export] public StatResource StatResource{ get; private set; }

    public override void _Ready() {
        StatResource.OnUpdate += HandleUpdate;
        HandleUpdate();
    }

    private void HandleUpdate() {
        Text = StatResource.StatValue.ToString();
    }
}
