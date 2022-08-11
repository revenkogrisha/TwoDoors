using TwoDoors.Scene;
using Zenject;

namespace TwoDoors.GUI
{
    public class PauseButton : UIButton
    {
        [Inject] private GamePause _pause;
        [Inject] private Score _score;

        #region MonoBehaviour

        private void OnEnable()
        {
            base.OnEnable();

            _score.OnGameFinished += Disable;
            _score.OnGameOvered += Disable;
        }

        private void OnDisable()
        {
            base.OnDisable();

            _score.OnGameFinished -= Disable;
            _score.OnGameOvered -= Disable;
        }

        #endregion

        protected override void OnClicked()
        {
            _pause.TryPause();
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
