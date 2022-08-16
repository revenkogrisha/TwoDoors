namespace TwoDoors.GUI
{
    public class BackToMenuButton : LoaderButton
    {
        protected override void Load()
        {
            _loader.BackToMenu();
        }
    }
}