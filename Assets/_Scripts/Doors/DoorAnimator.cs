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
            _animator.enabled = true;
            _animator.SetBool(Opened, true);
        }

        public void Close()
        {
            _animator.enabled = true;
            _animator.SetBool(Opened, false);
        }
    }
}
