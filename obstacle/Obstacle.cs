using Godot;
using System;

public partial class Obstacle : Node2D
{
    [Export] public double Speed = 126;

    [Signal]
    public delegate void ScoreEventHandler();

    public override void _Ready()
    {
        // Select a random template and move it under the parent, removing all others.
        var rand = new Random();
        var templates = GetNode<Node2D>("Templates");
        var template = templates.GetChild<TileMapLayer>(rand.Next(templates.GetChildCount()));
        templates.RemoveChild(template);
        AddChild(template);
        RemoveChild(templates);
    }
    
    public override void _Process(double delta)
    {
        var position = Position;
        position.X -= (float)(Speed * delta);
        Position = position;
    }

    private void OnScore(Node2D _body)
    {
        EmitSignal(SignalName.Score);
    }
}
