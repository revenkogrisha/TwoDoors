using TwoDoors.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TwoDoors.UI
{
    public class PlayLevelButton : MonoBehaviour
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private Button _button;

        #region MonoBehaviour

        private void OnEnable()
        {
            _button.onClick.AddListener(PlayLevel);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        #endregion

        private void PlayLevel()
        {
            EventHolder.RaiseLoadingStarted(_levelIndex);
        }
    }
}
