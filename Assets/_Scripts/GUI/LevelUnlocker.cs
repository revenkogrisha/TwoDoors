using TwoDoors.Scene;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private Button[] _allButtons;

    private void Start()
    {
        var lastFinishedLevelIndex = PlayerPrefs.GetInt(GameState.LastFinishedLevel, 0);

        for (int i = 0; i < lastFinishedLevelIndex; i++)
        {
            _allButtons[i].interactable = true;

            if (i > lastFinishedLevelIndex
                ||  i + 1 >= _allButtons.Length)
                continue;

            _allButtons[i + 1].interactable = true;
        }
    }
}
