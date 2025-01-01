using Godot;

public partial class Game : Node2D
{
    private Player _player;
    private Label _gameOverText;
    private Timer _spawnTimer;
    private Node2D _spawnPoint;
    private PackedScene _obstacleScene;

    public override void _Ready()
    {
        _player = GetNode<Player>("Player");
        _gameOverText = GetNode<Label>("UI/GameOverText");
        _spawnTimer = GetNode<Timer>("SpawnTimer");
        _spawnPoint = GetNode<Node2D>("SpawnPoint");
        _obstacleScene = ResourceLoader.Load<PackedScene>("res://obstacle/obstacle.tscn");
    }

    private void OnPlayerHit()
    {
        _player.Hide();
        _gameOverText.Show();
    }

    private void OnSpawn()
    {
        var obstacle = (Node2D)_obstacleScene.Instantiate();
        obstacle.SetPosition(_spawnPoint.Position);
        AddChild(obstacle);
    }

    private void OnDespawn(Node2D body)
    {
        body.QueueFree();
    }
}
