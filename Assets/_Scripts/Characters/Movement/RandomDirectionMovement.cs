using UnityEngine;
using TwoDoors.Scene;

namespace TwoDoors.Characters.Moveable
{
    [RequireComponent(typeof(Timer))]
    [DisallowMultipleComponent]
    public class RandomDirectionMovement : ForwardMovement
    {
        [SerializeField] private int _nonChangingDirectionTime = 2;

        private Transform _transform;
        protected Timer _timer;

        #region MonoBehaviour

        private void Awake()
        {
            base.Awake();
            _transform = transform;
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

            var random = Random.Range(0, 2);
            if (random == 0)
            {
                ChangeDirection();
            }
        }

        private void ChangeDirection()
        {
            var direction = (float)Direction * -1f;
            Direction = (MovementDirection)direction;
            ReflectTransform();
        }

        private void ReflectTransform()
        {
            var newScale = new Vector2(
                            _transform.localScale.x * -1f, _transform.localScale.y);

            _transform.localScale = newScale;
        }
    }
}
