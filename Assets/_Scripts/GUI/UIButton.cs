using UnityEngine;
using UnityEngine.UI;

namespace TwoDoors.GUI
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour
    {
        private Button _button;
    
        #region MonoBehaviour

        protected void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        #endregion

        protected abstract void OnClicked();
    }
}
