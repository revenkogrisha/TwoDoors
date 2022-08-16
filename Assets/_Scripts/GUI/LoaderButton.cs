using UnityEngine;

namespace TwoDoors.GUI
{
    public abstract class LoaderButton : UIButton
    {
        [SerializeField] protected GameSceneLoader _loader;

        protected override void OnClicked()
        {
            Load();
        }

        protected abstract void Load();
    }
}