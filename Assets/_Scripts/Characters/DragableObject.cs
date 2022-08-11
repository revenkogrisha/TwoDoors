using System;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [DisallowMultipleComponent]
    public class DragableObject : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _dragSound;
        [SerializeField] private AudioSource _mouseUpSound;

        [Inject] private GamePause _pause;
        [Inject] private Score _score;

        private bool _isOnDrag = false;
        private Transform _transform;
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;

        private CharacterAnimator _characterAnimator;
        private CharacterAudio _audio;

        public event Action OnDragStarted;
        public event Action OnDragStopped;

        public bool IsOnDrag => _isOnDrag;

        #region MonoBehaviour

        private void Awake()
        {
            _characterAnimator = new(this, _animator);
            _audio = new(this, _dragSound, _mouseUpSound);

            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }
        private void OnEnable()
        {
            _score.OnGameFinished += DisableDrag;
            _score.OnGameFinished += DisableMovement;
            _score.OnGameOvered += DisableDrag;
            _score.OnGameOvered += DisableMovement;

            _pause.OnGamePaused += DisableDrag;
            _pause.OnGamePaused += DisableMovement;
            _pause.OnGameContinued += EnableMovement;
            _pause.OnGameContinued += EnableDrag;
        }

        private void OnDisable()
        {
            _audio.Disable();
            _characterAnimator.Disable();

            _score.OnGameFinished -= DisableMovement;
            _score.OnGameFinished -= DisableDrag;
            _score.OnGameOvered -= DisableDrag;
            _score.OnGameOvered -= DisableMovement;

            _pause.OnGamePaused -= DisableDrag;
            _pause.OnGamePaused -= DisableMovement;
            _pause.OnGameContinued -= EnableMovement;
            _pause.OnGameContinued -= EnableDrag;
        }

        private void OnMouseDrag()
        {
            if (!_isOnDrag)
                OnDragStarted?.Invoke();

            SetTransformToTouchPoint();
            DisableMovement();
            _isOnDrag = true;
        }

        private void OnMouseUp()
        {
            OnDragStopped?.Invoke();
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

