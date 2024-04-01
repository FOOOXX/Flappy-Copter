using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _spawner.Activate();
        Time.timeScale = 1f;
    }

    private void OnRestartButtonClick()
    {
        _player.Reset();
        _endScreen.Close();
        _spawner.Activate();
        Time.timeScale = 1f;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _endScreen.Open();
        _spawner.Deactivate();
    }
}
