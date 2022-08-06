using UnityEngine;
using TwoDoors.Scene;

namespace TwoDoors.Characters.Movement
{
    [RequireComponent(typeof(Timer))]
    public class RandomDirectionMovement : ForwardMovement
    {
        [SerializeField] private int _nonChangingDirectionTime = 2;

        protected Timer _timer;

        #region MonoBehaviour

        private void Awake()
        {
            base.Awake();
            _timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
            _timer.OnCooldownPassed += TryChangeDirection;
        }

        private void OnDisable()
        {
            _timer.OnCooldownPassed -= TryChangeDirection;
        }

        #endregion

        private void TryChangeDirection()
        {
            if (_timer.TimeInSeconds < _nonChangingDirectionTime)
                return;

            if (Random.Range(0, 2) == 0)
            {
                ChangeDirection();
            }
        }

        private void ChangeDirection()
        {
            var direction = (float)Direction * -1f;
            Direction = (MovementDirection)direction;
        }
    }
}
