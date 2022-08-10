using UnityEngine;

namespace TwoDoors.Doors
{
    public class DoorAnimator
    {
        private const string Opened = nameof(Opened);
    
        private Door _door;
        private Animator _animator;
        private int _openedId;

        public DoorAnimator(Door door, Animator animator)
        {
            _door = door;
            _animator = animator;

            _openedId = Animator.StringToHash(Opened);

            _door.OnDoorOpened += Open;
            _door.OnDoorClosed += Close;
        }

        public void Disable()
        {
            _door.OnDoorOpened -= Open;
            _door.OnDoorClosed -= Close;
        }

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

            _animator.SetBool(_openedId, false);
        }
    }
}
