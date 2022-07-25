using UnityEngine;

namespace TwoDoors.Characters.Movement
{
    public class SinMovement : MonoBehaviour, IMoveable
    {
        [SerializeField] private float _speed;

        private readonly float _waveFriquency = 2f;
        private readonly float _waveWidth = 2f;
        private float _startY;
        private float _birthTime;

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
            _transform = transform;
            _startY = Pos.y;
            _birthTime = Time.time;
        }

        public void Move()
        {
            Vector3 tempPos = Pos;
            float age = Time.time - _birthTime;
            float theta = Mathf.PI * 2 * age / _waveFriquency;
            float sinTheta = Mathf.Sin(theta);

            tempPos.y = _startY + _waveWidth * sinTheta;
            Pos = tempPos;

            var tempPose = Pos;
            tempPos.x += _speed * Time.deltaTime;
            Pos = tempPos;
        }
    }
}
