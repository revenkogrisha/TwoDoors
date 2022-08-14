using UnityEngine;
using Zenject;

namespace TwoDoors.Scene
{
    [DisallowMultipleComponent]
    public class LevelBound : MonoBehaviour
    {
        [Inject] private Score _score;

        #region MonoBehaviour

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var other = collision.gameObject;

            Destroy(other);
            _score.InitFail();
        }

        #endregion
    }
}
