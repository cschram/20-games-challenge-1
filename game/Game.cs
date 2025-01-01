using Godot;

public partial class Game : Node2D
{
    private Player _player;
    private Label _gameOverText;
    private Timer _spawnTimer;
    private Node2D _spawnPoint;
    private Label _scoreText;
    private AudioStreamPlayer2D _scoreSound;
    
    private PackedScene _obstacleScene;

    private bool _isGameOver = false;
    private int _score = 0;

    public override void _Ready()
    {
        _player = GetNode<Player>("Player");
        _gameOverText = GetNode<Label>("UI/GameOverText");
        _spawnTimer = GetNode<Timer>("SpawnTimer");
        _spawnPoint = GetNode<Node2D>("SpawnPoint");
        _scoreText = GetNode<Label>("UI/ScoreText");
        _scoreSound = GetNode<AudioStreamPlayer2D>("ScoreSound");
        
        _obstacleScene = ResourceLoader.Load<PackedScene>("res://obstacle/obstacle.tscn");
    }

    private void OnPlayerHit()
    {
        _isGameOver = true;
        _player.Hide();
        _gameOverText.Show();
    }

    private void OnSpawn()
    {
        var obstacle = (Obstacle)_obstacleScene.Instantiate();
        obstacle.SetPosition(_spawnPoint.Position);
        obstacle.Score += OnScore;
        AddChild(obstacle);
    }

    private void OnDespawn(Node2D body)
    {
        body.QueueFree();
    }

    private void OnScore()
    {
        if (!_isGameOver)
        {
            _score++;
            _scoreText.Text = "Score: " + _score.ToString();
            _scoreSound.Play();
        }
    }
}
