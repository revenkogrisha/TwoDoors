using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.GUI
{
    [DisallowMultipleComponent]
    public class GameUIView : MonoBehaviour
    {
        private const string Opened = nameof(Opened);

        [SerializeField] private Animator _finishPanelAnimator;
        [SerializeField] private Animator _gameOverPanelAnimator;

        [Inject] private Score _score;

        private int _openedId;

        #region MonoBehaviour

        private void Awake()
        {
            _openedId = Animator.StringToHash(Opened);
        }

        private void OnEnable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnGameFinished += OpenFinishPanel;

            if (_score is RecordScore recordScore)
                recordScore.OnRecordBreaked += OpenFinishPanel;

            _score.OnGameOvered += OpenGameOverPanel;
        }

        private void OnDisable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnGameFinished -= OpenFinishPanel;

            if (_score is RecordScore recordScore)
                recordScore.OnRecordBreaked -= OpenFinishPanel;

            _score.OnGameOvered -= OpenGameOverPanel;
        }

        #endregion

        public void OpenFinishPanel()
        {
            _finishPanelAnimator.gameObject.SetActive(true);
            _finishPanelAnimator.SetTrigger(_openedId);
        }

        public void OpenGameOverPanel()
        {
            _gameOverPanelAnimator.gameObject.SetActive(true);
            _finishPanelAnimator.SetTrigger(_openedId);
        }
    }
}
