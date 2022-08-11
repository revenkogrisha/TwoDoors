using System;
using System.Collections;
using TwoDoors.Characters.Movement;
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

        private IMoveable _moveable;
        private DragableObject _dragable;
        private bool _isTryingToPass = false;
        private Door _doorEntered;

        public CharactersId Id => _id;

        public bool IsTryingToPass => _isTryingToPass;

        #region MonoBehaviour

        private void Awake()
        {
            _moveable = GetComponent<IMoveable>();
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Router.Route<Door>(TryEnterTheDoor, collision);
        }

        private void OnTriggerExit2D()
        {
            _doorEntered?.Exit();
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

        private void TryEnterTheDoor(Door door)
        {
            if (door.IsCharacterEntered
                || !_dragable.IsOnDrag)
                return;

            _doorEntered = door;
            _doorEntered.Enter(this);
        }
    }
}

