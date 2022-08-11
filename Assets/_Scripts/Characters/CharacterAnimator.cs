using UnityEngine;

namespace TwoDoors.Characters
{
    public class CharacterAnimator
    {
        private const string IsOnDrag = nameof(IsOnDrag);

        private Animator _animator;
        private int _isOnDragId;

        public CharacterAnimator(Animator animator)
        {
            _animator = animator;
            _isOnDragId = Animator.StringToHash(IsOnDrag);
        }

        public void SetAsOnDrag()
        {
            _animator.SetBool(_isOnDragId, true);
        }

        public void SetAsNotOnDrag()
        {
            _animator.SetBool(_isOnDragId, false);
        }
    }
}