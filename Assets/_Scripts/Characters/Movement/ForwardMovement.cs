using UnityEngine;

namespace TwoDoors.Characters.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ForwardMovement : MonoBehaviour, IMoveable
    {
        [SerializeField, Range(0, float.PositiveInfinity)] protected float Speed;
        [SerializeField] protected MovementDirection Direction;

        private Rigidbody2D _rigidbody2D;

        #region MonoBehaviour

        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        #endregion

        public virtual void Move()
        {
            Vector3 velocity = new(Speed * (float)Direction, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = velocity;
        }
    }
}

