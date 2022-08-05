using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause Instance;

    [SerializeField] private GameObject _pausePanel;

    private bool _isOnPause = false;

    public event Action OnGamePaused;
    public event Action OnGameContinued;

    #region MonoBehaviour

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null
            && Instance != this)
            throw new Exception($"Singleton initialize exception in {gameObject.name}!");
    }

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TryPause();
    }

    public void TryPause()
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
