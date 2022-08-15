using TwoDoors.Save;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[DisallowMultipleComponent]
public class LevelButtonUnlocker : MonoBehaviour
{
    private const string LastFinishedLevel = nameof(LastFinishedLevel);

    [SerializeField] private Button[] _allButtons;

    [Inject] private SaveService _saveService;

    #region MonoBehaviour

    private void Awake()
    {
        _saveService.Load();

        var lastFinishedLevelIndex = _saveService.LastFinishedLevel;

        for (int i = 0; i < lastFinishedLevelIndex; i++)
        {
            _allButtons[i].interactable = true;

            if (i > lastFinishedLevelIndex
                ||  i + 1 >= _allButtons.Length)
                break;

            _allButtons[i + 1].interactable = true;
        }
    }

    #endregion
}
