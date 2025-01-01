using Godot;
using System;

public partial class Obstacle : Node2D
{
    static Random rand = new Random();
    
    [Export] public double Speed = 126;

    public override void _Ready()
    {
        var r = rand.Next(GetChildCount());
        for (var i = 0; i < GetChildCount(); i++)
        {
            var child = (TileMapLayer)GetChild(i);
            if (i == r)
            {
                child.Show();
            }
            else
            {
                child.QueueFree();
            }
        }
    }
    
    public override void _Process(double delta)
    {
        var position = Position;
        position.X -= (float)(Speed * delta);
        Position = position;
    }
}
