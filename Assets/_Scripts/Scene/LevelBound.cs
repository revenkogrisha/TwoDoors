using UnityEngine;

namespace TwoDoors.Scene
{
    public class LevelBound : MonoBehaviour
    {
        [SerializeField] private GameState _game;

        #region MonoBehaviour

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var other = collision.gameObject;

            CharacterPassedAway(other);
        }

        #endregion

        private void CharacterPassedAway(GameObject characterObject)
        {
            Destroy(characterObject);
            _game.SubtractScore();
        }
    }
}
