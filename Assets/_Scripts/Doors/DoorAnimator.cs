using UnityEngine;

namespace TwoDoors.Doors
{
    [DisallowMultipleComponent]
    public class DoorAnimator : INonMonoEventSubscriber
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
            EnableAnimatorIfDisabled();
            _animator.SetBool(_openedId, true);
        }

        public void Close()
        {
            EnableAnimatorIfDisabled();
            _animator.SetBool(_openedId, false);
        }

        private void EnableAnimatorIfDisabled()
        {
            if (_animator.enabled)
                return;

            _animator.enabled = true;
        }
    }
}
