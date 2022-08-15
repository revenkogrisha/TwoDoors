using UnityEngine;

namespace TwoDoors.Characters.Moveable
{
    [RequireComponent(typeof(Rigidbody2D))]
    [DisallowMultipleComponent]
    public class ForwardMovement : Movement
    {
        protected Rigidbody2D Rigidbody2D;

        #region MonoBehaviour

        protected void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        #endregion

        public override void Move()
        {
            var velocity = new Vector3(
                Speed * (float)Direction,
                Rigidbody2D.velocity.y);

            Rigidbody2D.velocity = velocity;
        }
    }
}

