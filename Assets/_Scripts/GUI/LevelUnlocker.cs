using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class LevelUnlocker : MonoBehaviour
{
    private const string LastFinishedLevel = nameof(LastFinishedLevel);

    [SerializeField] private Button[] _allButtons;

    #region MonoBehaviour

    private void Start()
    {
        var lastFinishedLevelIndex = PlayerPrefs.GetInt(LastFinishedLevel, 0);

        for (int i = 0; i < lastFinishedLevelIndex; i++)
        {
            _allButtons[i].interactable = true;

            if (i > lastFinishedLevelIndex
                ||  i + 1 >= _allButtons.Length)
                continue;

            _allButtons[i + 1].interactable = true;
        }
    }

    #endregion
}
