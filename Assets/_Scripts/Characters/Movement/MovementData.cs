using UnityEngine;

namespace TwoDoors.Characters.Moveable
{
    [CreateAssetMenu(fileName = "New MovementData", menuName = "MovementData")]
    public class MovementData : ScriptableObject
    {
        public float Speed;
        public MovementDirection Direction;
    }
}