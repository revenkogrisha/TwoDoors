using TwoDoors.Scene;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DragableObject : MonoBehaviour
    {
        [SerializeField] private GameState _game;
        private bool _isOnDrag = false;
        private Transform _transform;
        private Rigidbody2D _rigidbody2D;

        public bool IsOnDrag => _isOnDrag;

        #region MonoBehaviour

        private void Awake()
        {
            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            _game.OnGameFinished += DisableMovement;
            _game.OnGameOvered += DisableMovement;
        }

        private void OnDisable()
        {
            _game.OnGameFinished -= DisableMovement;
            _game.OnGameOvered -= DisableMovement;
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

            var _touchPoint = Camera.main.ScreenToWorldPoint(pointPosition);
            _touchPoint.z = 0;

            _transform.position = _touchPoint;
        }

        private void DisableMovement()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic; 
        }

        private void EnableMovement()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}

