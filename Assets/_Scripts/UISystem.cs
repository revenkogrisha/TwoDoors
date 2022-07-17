using UnityEngine;
using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _gameOverPanel;

    private void OnEnable()
    {
        EventHolder.OnGameFinished += OpenFinishPanel;
        EventHolder.OnGameOvered += OpenGameOverPanel;
    }

    private void OnDisable()
    {
        EventHolder.OnGameFinished -= OpenFinishPanel;
        EventHolder.OnGameOvered -= OpenGameOverPanel;
    }

    public void OpenFinishPanel()
    {
        _finishPanel.SetActive(true);
    }

    public void OpenGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        // TODO: dfgdfg
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        var thisSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisSceneIndex);
    }
}
