using System.Collections;
using TMPro;
using TwoDoors.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TwoDoors.UI
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Slider _loadingBar;
        [SerializeField] private TMP_Text _loadingText;

        private AsyncOperation _loadingOperation;

        #region MonoBehaviour

        private void OnEnable()
        {
            EventHolder.OnLoadingStarted += StartLoading;
        }

        private void OnDisable()
        {
            EventHolder.OnLoadingStarted -= StartLoading;
        }

        #endregion

        private void StartLoading(int index)
        {
            _menu.SetActive(false);
            _loadingScreen.SetActive(true);


            StartCoroutine(LoadLevelAsync(index));
        }

        private IEnumerator LoadLevelAsync(int index)
        {
            _loadingOperation = SceneManager.LoadSceneAsync(index);

            while (!_loadingOperation.isDone)
            {
                SetUpLoadingBar();

                yield return null;
            }
        }

        private void SetUpLoadingBar()
        {
            var progress = Mathf.Clamp01(_loadingOperation.progress / .9f);

            _loadingBar.value = progress;
            _loadingText.text = Mathf.Round(progress * 100f) + "%";
        }
    }
}
