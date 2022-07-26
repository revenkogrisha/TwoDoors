using TwoDoors.Characters;
using UnityEngine;

namespace TwoDoors.Doors
{
    public class DoorAnimator : MonoBehaviour
    {
        private const string Opened = nameof(Opened);

        [SerializeField] private Animator _animator;

        public void Open()
        {
            if (!_animator.enabled)
                _animator.enabled = true;

            _animator.SetBool(Opened, true);
        }

        public void Close()
        {
            if (!_animator.enabled)
                _animator.enabled = true;

            _animator.SetBool(Opened, false);
        }
    }
}
