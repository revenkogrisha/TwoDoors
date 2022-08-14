using UnityEngine;

namespace TwoDoors.Characters.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [DisallowMultipleComponent]
    public class ForwardMovement : MonoBehaviour, IMoveable
    {
        [SerializeField] protected MovementDirection Direction;
        [SerializeField, Range(0f, 10f)] protected float Speed;

        protected Rigidbody2D Rigidbody2D;

        #region MonoBehaviour

        protected void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        #endregion

        public virtual void Move()
        {
            Vector3 velocity = new(Speed * (float)Direction, Rigidbody2D.velocity.y);
            Rigidbody2D.velocity = velocity;
        }
    }
}

