using System.Collections;
using TwoDoors.Characters.Movement;
using TwoDoors.Data;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Collider2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharactersId _id;

        private IMoveable _moveable;
        private bool _isTryingToPass = false;

        public CharactersId Id
        {
            get
            {
                return _id;
            }
        }

        public bool IsTryingToPass => _isTryingToPass;

        #region MonoBehaviour

        private void Awake()
        {
            _moveable = GetComponent<IMoveable>();

            if (_moveable == null)
                throw new System.NullReferenceException(
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

