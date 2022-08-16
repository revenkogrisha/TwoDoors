using UnityEngine;
using UnityEngine.UI;

namespace TwoDoors.GUI.Buttons
{
    [RequireComponent(typeof(Button))]
    [DisallowMultipleComponent]
    public abstract class UIButton : MonoBehaviour
    {
        [SerializeField] protected AudioSource Audio;

        private Button _button;

        #region MonoBehaviour

        protected void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected void OnEnable()
        {
            _button.onClick.AddListener(PlaySound);
            _button.onClick.AddListener(OnClicked);
            _button.onClick.AddListener(PlaySound);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        #endregion

        protected abstract void OnClicked();

        private void PlaySound()
        {
            if (Audio != null)
                Audio.Play();
        }
    }
}
