using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class DragableObject : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [Inject] private GameState _game;
        [Inject] private Score _score;

        private bool _isOnDrag = false;
        private Transform _transform;
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;
        private CharacterAnimator _characterAnimator;

        public bool IsOnDrag => _isOnDrag;

        #region MonoBehaviour

        private void Awake()
        {
            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            _characterAnimator = new(_animator);
        }
        private void OnEnable()
        {
            _score.OnGameFinished += DisableDrag;
            _score.OnGameOvered += DisableDrag;

            var pause = _game.Pause;
            pause.OnGamePaused += DisableDrag;
            pause.OnGameContinued += EnableDrag;
        }

        private void OnDisable()
        {
            _score.OnGameFinished -= DisableDrag;
            _score.OnGameOvered -= DisableDrag;

            var pause = _game.Pause;
            pause.OnGamePaused -= DisableDrag;
            pause.OnGameContinued -= EnableDrag;
        }

        private void OnMouseDrag()
        {
            SetTransformToTouchPoint();
            DisableMovement();
            SetAsOnDrag();
        }

        private void OnMouseUp()
        {
            EnableMovement();
            SetAsNotOnDrag();
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

        public void SetAsOnDrag()
        {
            _characterAnimator.SetAsOnDrag();
            _isOnDrag = true;
        }

        public void SetAsNotOnDrag()
        {
            _characterAnimator.SetAsNotOnDrag();
            _isOnDrag = false;
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

