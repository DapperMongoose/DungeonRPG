using Godot;
using System;

public partial class UIContainer : VBoxContainer {
    [Export] public ContainerType Container{ get; private set; }
}
