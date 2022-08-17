using System;
using System.Collections;
using TwoDoors.Characters.Moveable;
using TwoDoors.Doors;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(DragableObject))]
    [DisallowMultipleComponent]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharactersId _id;

        private Movement _moveable;
        private DragableObject _dragable;
        private bool _isTryingToPass = false;

        public CharactersId Id => _id;

        public bool IsTryingToPass => _isTryingToPass;

        public bool IsOnDrag { get { return _dragable.IsOnDrag; } }

        #region MonoBehaviour

        private void Awake()
        {
            _moveable = GetComponent<Movement>();
            _dragable = GetComponent<DragableObject>();

            if (_moveable == null)
                throw new NullReferenceException(
                    "Character needs a sctipt implementing IMoveable");
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnMouseUp()
        {
            StartCoroutine(TryToPass());
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Tools.InvokeIfNotNull<Door>(other, TryOpen);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Tools.InvokeIfNotNull<Door>(other, TryClose);
        }

        #endregion

        public void Move()
        {
            _moveable.Move();
        }

        private IEnumerator TryToPass()
        {
            _isTryingToPass = true;

            yield return new WaitForSeconds(.1f);

            _isTryingToPass = false;
        }

        private void TryOpen(Door door)
        {
            if (IsOnDrag)
                door.Open();
        }

        private void TryClose(Door door)
        {
            if (IsOnDrag)
                door.Close();
        }
    }
}

