using Godot;

public abstract partial class Character : CharacterBody3D {

    [Export]
    private StatResource[] _stats;
    
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode {get; private set;}
    [Export] public Sprite3D SpriteNode {get; private set;}
    [Export] public StateMachine StateMachineNode {get; private set;}
    [Export] public Area3D HurtBoxNode{ get; private set; }
    [Export] public Area3D HitBoxNode{ get; private set; }
    [Export] public CollisionShape3D HitBoxShapeNode{ get; private set; }
    
    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode{ get; private set;}
    [Export] public NavigationAgent3D AgentNode{ get; private set; }
    [Export] public Area3D ChaseAreaNode { get; private set; }
    [Export] public Area3D AttackAreaNode{ get; private set; }
    
    public Vector2 Direction;

    public override void _Ready() {
        base._Ready();
        HurtBoxNode.AreaEntered += HandleHurtBoxEntered;
    }

    public void Flip() {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) {
            return;
        }
        
        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }
    
    private void HandleHurtBoxEntered(Area3D area) {
        if (area is not IHitbox hitbox) {
            return;
        }
        
        StatResource health = GetStatResource(Stat.Health);

        float damage = hitbox.GetDamage();

        health.StatValue -= damage;
    }

    public StatResource GetStatResource(Stat stat) {
        foreach (StatResource element in _stats) {
            if (element.StatType == stat) {
                return element;
            }
        }

        return null;
    }

    public void ToggleHitBox(bool flag) {
        HitBoxShapeNode.Disabled = flag;
    }
}
