using UnityEngine;

namespace TwoDoors.GUI
{
    public class Panel : MonoBehaviour
    {
        private const string Opened = nameof(Opened);

        [SerializeField] private Animator _animator;

        private int _openedId;

        #region MonoBehaviour

        private void Awake()
        {
            _openedId = Animator.StringToHash(Opened);
        }

        #endregion

        public void Show()
        {
            Activate();
            _animator.SetBool(_openedId, true);
        }

        public void Close()
        {
            _animator.SetBool(_openedId, false);
        }

        public void Activate() => gameObject.SetActive(true);

        public void Disactivate() => gameObject.SetActive(false);
    }
}