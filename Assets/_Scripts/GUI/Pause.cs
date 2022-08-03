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
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

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
        OnGamePaused?.Invoke();
        _pausePanel.SetActive(true);
    }

    private void ContinueGame()
    {
        OnGameContinued?.Invoke();
        _pausePanel.SetActive(false);
    }
}
