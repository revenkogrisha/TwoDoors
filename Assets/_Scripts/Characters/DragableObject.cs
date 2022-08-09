using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class DragableObject : MonoBehaviour
    {
        [Inject] private GameState _game;

        private bool _isOnDrag = false;
        private Transform _transform;
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;

        public bool IsOnDrag => _isOnDrag;

        #region MonoBehaviour

        private void Awake()
        {
            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }
        private void OnEnable()
        {
            _game.OnGameFinished += DisableDrag;
            _game.OnGameOvered += DisableDrag;

            var pause = _game.Pause;
            pause.OnGamePaused += DisableDrag;
            pause.OnGameContinued += EnableDrag;
        }

        private void OnDisable()
        {
            _game.OnGameFinished -= DisableDrag;
            _game.OnGameOvered -= DisableDrag;

            var pause = _game.Pause;
            pause.OnGamePaused -= DisableDrag;
            pause.OnGameContinued -= EnableDrag;
        }

        private void OnMouseDrag()
        {
            SetTransformToTouchPoint();
            DisableMovement();
            _isOnDrag = true;
        }

        private void OnMouseUp()
        {
            EnableMovement();
            _isOnDrag = false;
        }

        #endregion

        private void SetTransformToTouchPoint()
        {
            var mousePosition = Input.mousePosition;
            var cameraZ = Camera.main.transform.position.z;
            var pointPosition = new Vector3( mousePosition.x, mousePosition.y, cameraZ);

            var touchPoint = Camera.main.ScreenToWorldPoint(pointPosition);
            touchPoint.z = 0;

            _transform.position = touchPoint;
        }

        private void DisableMovement()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }

        private void EnableMovement()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void DisableDrag()
        {
            _collider2D.enabled = false;
        }

        private void EnableDrag()
        {
            _collider2D.enabled = true;
        }
    }
}

