using UnityEngine;
using Zenject;
using TwoDoors.Scene;
using TMPro;

namespace TwoDoors.GUI
{
    public class ScoreView : ITMProUpdater
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        [Inject] private Score _score;

        #region MonoBehaviour

        private void Start()
        {
            UpdateScore();
        }

        private void OnEnable()
        {
            _score.OnPlayerScored += UpdateScore;
            _score.OnGameOvered += Deactivate;
        }

        private void OnDisable()
        {
            _score.OnPlayerScored -= UpdateScore;
            _score.OnGameOvered -= Deactivate;
        }

        #endregion

        private void UpdateScore()
        {
            var text = _score.Amount.ToString();
            UpdateText(_scoreText, text);
        }

        private void Deactivate() => _scoreText.gameObject.SetActive(false);
    }
}