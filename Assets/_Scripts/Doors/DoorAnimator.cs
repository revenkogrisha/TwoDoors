using UnityEngine;

namespace TwoDoors.Doors
{
    [RequireComponent(typeof(Door))]
    public class DoorAnimator : MonoBehaviour
    {
        private const string Opened = nameof(Opened);

        [SerializeField] private Animator _animator;

        private Door _door;

        #region MonoBehaviour

        private void Awake()
        {
            _door = GetComponent<Door>();
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

            print(1);
            _animator.SetBool(Opened, true);
        }

        public void Close()
        {
            if (!_animator.enabled)
                _animator.enabled = true;

            print(2);
            _animator.SetBool(Opened, false);
        }
    }
}
