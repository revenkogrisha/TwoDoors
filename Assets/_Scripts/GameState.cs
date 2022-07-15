using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private int _defaultReward = 1;
    [SerializeField] private int _defaultPunishment = 2;

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
        //MAKE THIS
    }

    private void GameOver()
    {
        //Make this
    }
}
