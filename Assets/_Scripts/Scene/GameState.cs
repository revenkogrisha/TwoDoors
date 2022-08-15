using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.Scene
{
    [DisallowMultipleComponent]
    public class GameState : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _levelId;

        [Inject] private Score _score;
        [Inject] private GamePause _pause;
        [Inject] private SaveService _saveService;

        private LevelData _levelData;

        #region MonoBehaviour

        private void Awake()
        {
            _levelData = new(_levelId, _saveService);

            _pause.ContinueTimeFlow();
        }

        private void OnEnable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnGameFinished += FinishLevel;

            if (_score is RecordScore recordScore)
                recordScore.OnRecordBreaked += GameOver;

            _score.OnGameOvered += GameOver;
        }

        private void OnDisable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnGameFinished -= FinishLevel;

            if (_score is RecordScore recordScore)
                recordScore.OnRecordBreaked -= GameOver;

            _score.OnGameOvered -= GameOver;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _pause.TryPause();
        }

        #endregion

        private void FinishLevel()
        {
            _pause.StopTimeFlowWithDelay(_pause.PopupDelaySeconds);
            _levelData.SaveLevel();
        }

        private void GameOver()
        {
            _pause.StopTimeFlowWithDelay(_pause.PopupDelaySeconds);
        }
    }
}
