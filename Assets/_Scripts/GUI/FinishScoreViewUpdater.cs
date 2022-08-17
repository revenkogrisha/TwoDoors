using TwoDoors.Scene;

namespace TwoDoors.GUI
{
    public class FinishScoreViewUpdater : ScoreViewUpdater
    {
        private void OnEnable()
        {
            if (Score is RecordScore recordScore)
            {
                recordScore.OnRecordBreaked += UpdateScoreTexts;
                recordScore.OnGameOvered += UpdateScoreTexts;
            }
        }

        private void OnDisable()
        {
            if (Score is RecordScore recordScore)
            {
                recordScore.OnRecordBreaked -= UpdateScoreTexts;
                recordScore.OnGameOvered -= UpdateScoreTexts;
            }

        }
    }
}