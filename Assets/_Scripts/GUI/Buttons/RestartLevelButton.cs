namespace TwoDoors.GUI.Buttons
{
    public class RestartLevelButton : LoaderButton
    {
        protected override void Load()
        {
            Loader.RestartLevel();
        }
    }
}