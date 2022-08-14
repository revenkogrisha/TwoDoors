using System;
using UnityEngine;

namespace TwoDoors.Scene
{
    [DisallowMultipleComponent]
    public abstract class Score : MonoBehaviour
    {
        [SerializeField] protected int DefaultReward = 1;

        public virtual event Action OnGameOvered;
        public virtual event Action OnPlayerScored;

        public int Amount { get; protected set; }

        public virtual void AddScore()
        {
            Amount += DefaultReward;
        }

        public abstract void InitFail();
    }
}