using UnityEngine;

namespace TwoDoors.Characters
{
    public class CharacterAnimator
    {
        private const string IsOnDrag = nameof(IsOnDrag);

        private Animator _animator;
        private DragableObject _dragable;
        private int _isOnDragId;

        public CharacterAnimator(DragableObject dragableObject, Animator animator)
        {
            _animator = animator;
            _dragable = dragableObject;
            _isOnDragId = Animator.StringToHash(IsOnDrag);

            _dragable.OnDragStarted += SetAsOnDrag;
            _dragable.OnDragStopped += SetAsNotOnDrag;
        }

        public void Disable()
        {
            _dragable.OnDragStarted -= SetAsOnDrag;
            _dragable.OnDragStopped -= SetAsNotOnDrag;
        }

        private void SetAsOnDrag()
        {
            _animator.SetBool(_isOnDragId, true);
        }

        private void SetAsNotOnDrag()
        {
            _animator.SetBool(_isOnDragId, false);
        }
    }
}