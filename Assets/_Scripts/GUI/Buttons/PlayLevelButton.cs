using UnityEngine;

namespace TwoDoors.GUI.Buttons
{
    public class PlayLevelButton : UIButton
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private LevelLoader _levelLoader;

        protected override void OnClicked()
        {
            _levelLoader.StartLoading(_levelIndex);
        }
    }
}
