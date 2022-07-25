using TwoDoors.Data;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class DragableObject : MonoBehaviour
    {
        public bool _isOnDrag = false;
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
            EventHolder.OnGameFinished += DisableMovement;
            EventHolder.OnGameOvered += DisableMovement;
        }

        private void OnDisable()
        {
            EventHolder.OnGameFinished -= DisableMovement;
            EventHolder.OnGameOvered -= DisableMovement;
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
            Vector3 pointPosition = new(
                        Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
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

