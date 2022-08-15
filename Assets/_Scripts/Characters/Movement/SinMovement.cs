using UnityEngine;

namespace TwoDoors.Characters.Moveable
{
    [RequireComponent(typeof(Rigidbody2D))]
    [DisallowMultipleComponent]
    public class SinMovement : Movement
    {
        private readonly float _waveFriquency = 2f;
        private readonly float _waveWidth = 6f;
        private float _startY;
        private float _birthTime;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

        private Vector3 Pos
        {
            get
            {
                return _transform.position;
            }
            set
            {
                _transform.position = value;
            }
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
            _startY = Pos.y;
            _birthTime = Time.time;
        }

        public override void Move()
        {
            Vector3 movement = Vector2.zero;
            float age = Time.time - _birthTime;
            float theta = Mathf.PI * 2 * age / _waveFriquency;
            float sinTheta = Mathf.Sin(theta);

            movement.y = _startY + _waveWidth * sinTheta - 1f;
            movement.x = Speed * (float)Direction;

            _rigidbody2D.velocity = movement;
        }
    }
}
