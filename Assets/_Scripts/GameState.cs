using UnityEngine;

public class GameState : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private int _defaultReward = 1;
    [SerializeField] private int _defaultPunishment = 2;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void AddScore()
    {
        _score += _defaultReward;
        if (_score >= 10)
            FinishLevel();
    }

    public void SubtractScore()
    {
        _score -= _defaultPunishment;
        if (_score < 0)
            GameOver();
    }

    private void FinishLevel()
    {
        Time.timeScale = 0;
        EventHolder.RaiseGameFinish();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        EventHolder.RaiseGameOver();
    }
}
