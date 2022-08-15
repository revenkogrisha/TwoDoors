using UnityEngine;

namespace TwoDoors.Characters.Moveable
{
    public abstract class Movement : MonoBehaviour
    {
        protected virtual float Speed { get; set; }

        protected MovementDirection Direction { get; set; }

        public abstract void Move();

        public void InitData(MovementData data)
        {
            Speed = data.Speed;
            Direction = data.Direction;
        }
    }
}
