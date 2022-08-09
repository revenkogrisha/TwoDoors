using UnityEngine;

namespace TwoDoors.Doors
{
    [RequireComponent(typeof(Door))]
    public class DoorAnimator : MonoBehaviour
    {
        private const string Opened = nameof(Opened);

        [SerializeField] private Animator _animator;

        private Door _door;
        private int _openedId;

        #region MonoBehaviour

        private void Awake()
        {
            _door = GetComponent<Door>();
            _openedId = Animator.StringToHash(Opened);
        }

        private void OnEnable()
        {
            _door.OnDoorOpened += Open;
            _door.OnDoorClosed += Close;
        }

        private void OnDisable()
        {
            _door.OnDoorOpened -= Open;
            _door.OnDoorClosed -= Close;
        }

        #endregion

        public void Open()
        {
            if (!_animator.enabled)
                _animator.enabled = true;

            _animator.SetBool(_openedId, true);
        }

        public void Close()
        {
            if (!_animator.enabled)
                _animator.enabled = true;

            _animator.SetBool(Opened, false);
        }
    }
}
