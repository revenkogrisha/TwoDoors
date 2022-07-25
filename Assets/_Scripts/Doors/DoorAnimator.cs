using TwoDoors.Characters;
using UnityEngine;

namespace TwoDoors.Doors
{
    public class DoorAnimator : MonoBehaviour
    {
        private const string Opened = nameof(Opened);

        [SerializeField] private Animator _animator;

        #region MonoBehaviour

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var other = collision.gameObject;
            var dragable = other.GetComponent<DragableObject>();

            if (dragable == null) 
                return;

            if (!dragable.IsOnDrag)
                return;
                
            Open();
        }

        private void OnTriggerExit2D()
        {
            Close();
        }

        #endregion

        public void Open()
        {
            _animator.SetBool(Opened, true);
        }

        private void Close()
        {
            _animator.SetBool(Opened, false);
        }
    }
}
