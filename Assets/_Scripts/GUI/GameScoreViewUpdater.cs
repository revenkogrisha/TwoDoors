namespace TwoDoors.GUI
{
    public class GameScoreViewUpdater : ScoreViewUpdater
    {
        #region MonoBehaviour

        private void Start()
        {
            UpdateScoreTexts();
        }

        private void OnEnable()
        {
            Score.OnPlayerScored += UpdateScoreTexts;
            Score.OnGameOvered += Deactivate;
        }

        private void OnDisable()
        {
            Score.OnPlayerScored -= UpdateScoreTexts;
            Score.OnGameOvered -= Deactivate;
        }

        #endregion
    }
}