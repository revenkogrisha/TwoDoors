using UnityEngine;

namespace TwoDoors.Characters.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ForwardMovement : MonoBehaviour, IMoveable
    {
        [SerializeField] protected float Speed;

        private Rigidbody2D _rigidbody2D;

        #region MonoBehaviour

        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        #endregion

        public virtual void Move()
        {
            _rigidbody2D.velocity = new Vector2(Speed, _rigidbody2D.velocity.y);
        }
    }
}

