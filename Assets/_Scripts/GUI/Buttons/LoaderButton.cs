using UnityEngine;

namespace TwoDoors.GUI.Buttons
{
    public abstract class LoaderButton : UIButton
    {
        protected GameSceneLoader Loader = new();

        protected override void OnClicked()
        {
            Load();
        }

        protected abstract void Load();
    }
}