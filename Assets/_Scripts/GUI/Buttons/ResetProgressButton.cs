using TwoDoors.Save;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace TwoDoors.GUI.Buttons
{
    public class ResetProgressButton : UIButton
    {
        [Inject] private SaveService _saveService;

        protected override void OnClicked()
        {
            PlayerPrefs.DeleteAll();
            _saveService.ResetProcess();

            var activeScene = SceneManager.GetActiveScene();
            var index = activeScene.buildIndex;
            SceneManager.LoadScene(index);
        }
    }
}