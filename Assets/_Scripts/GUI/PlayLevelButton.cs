using UnityEngine;
using UnityEngine.UI;

namespace TwoDoors.UI
{
    [RequireComponent(typeof(Button))]
    public class PlayLevelButton : MonoBehaviour
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private LevelLoader _levelLoader;

        private Button _button;

        #region MonoBehaviour

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

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
            _levelLoader.StartLoading(_levelIndex);
        }
    }
}
