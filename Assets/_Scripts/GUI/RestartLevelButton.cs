namespace TwoDoors.GUI
{
    public class RestartLevelButton : LoaderButton
    {
        protected override void Load()
        {
            _loader.RestartLevel();
        }
    }
}