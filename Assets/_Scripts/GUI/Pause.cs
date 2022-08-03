using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private bool _isOnPause = false;

    public event Action OnGamePaused;
    public event Action OnGameContinued;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TryPause();
    }

    private void TryPause()
    {
        if (!_isOnPause)
        {
            PauseGame();
        }
        else if (_isOnPause)
        {
            ContinueGame();
        }
    }

    private void PauseGame()
    {
        _pausePanel.SetActive(true);
        _isOnPause = true;
        OnGamePaused?.Invoke();
    }

    private void ContinueGame()
    {
        _pausePanel.SetActive(false);
        _isOnPause = false;
        OnGameContinued?.Invoke();

    }
}
