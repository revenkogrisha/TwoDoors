using UnityEngine;
using TwoDoors.Scene;

namespace TwoDoors.Characters.Movement
{
    [RequireComponent(typeof(Timer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class RandomJumpMovement : ForwardMovement
    {
        [SerializeField] private Vector2 _jumpForceRange;

        private Timer _timer;
        private Rigidbody2D _rigidbody2D;

        #region MonoBehaviour

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
            _timer.OnCooldownPassed += TryJump;
        }

        private void OnDisable()
        {
            _timer.OnCooldownPassed -= TryJump;
        }

        #endregion

        private void TryJump()
        {
            var random = Random.Range(0, 2);

            switch (random)
            {
                case 0:
                    JumpWithRandomForce();
                    break;
            }
        }

        private void JumpWithRandomForce()
        {
            var jumpForce = Random.Range(_jumpForceRange.x, _jumpForceRange.y);
            var force = new Vector2(0, jumpForce);

            _rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
