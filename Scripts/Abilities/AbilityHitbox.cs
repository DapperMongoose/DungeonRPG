using Godot;
using System;

public partial class AbilityHitbox : Area3D, IHitbox {
    
    public float GetDamage() {
        return GetOwner<Ability>().Damage;
    }
}