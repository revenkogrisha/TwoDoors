using TwoDoors.Scene;

namespace TwoDoors.GUI
{
    public class PauseButton : UIButton
    {
        private GameState _game;

        #region MonoBehaviour

        private void Awake()
        {
            base.Awake();
            _game = GameState.Instance;
        }

        private void OnEnable()
        {
            base.OnEnable();
            _game.OnGameFinished += Disable;
            _game.OnGameOvered += Disable;
        }

        private void OnDisable()
        {
            base.OnDisable();
            _game.OnGameFinished -= Disable;
            _game.OnGameOvered -= Disable;
        }

        #endregion

        protected override void OnClicked()
        {
            var pause = _game.Pause;
            pause.TryPause();
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
