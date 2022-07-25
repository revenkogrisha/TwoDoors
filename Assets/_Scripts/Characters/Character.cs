using System;
using System.Collections;
using TwoDoors.Characters.Movement;
using TwoDoors.Data;
using TwoDoors.Doors;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(DragableObject))]
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
            var other = collision.gameObject;
            _doorEntered = other.GetComponent<Door>();

            if (_doorEntered == null)
                return;

            if (_doorEntered.IsCharacterEntered
                || !_dragable.IsOnDrag)
            {
                _doorEntered = null;
                return;
            }

            _doorEntered.SetEnteredCharacter(this);
            _doorEntered.Open();
        }

        private void OnTriggerExit2D()
        {
            _doorEntered?.Close();
            _doorEntered?.RemoveEnteredCharacter();
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
    }
}

