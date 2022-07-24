using TwoDoors.Data;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Timer))]
    public class CharactersSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _charactersInGame;

        private Timer _timer;

        #region MonoBehaviour

        private void OnEnable()
        {
            _timer = GetComponent<Timer>();
            _timer.OnCooldownPassed += SpawnRandomCharacter;
        }

        private void OnDisable()
        {
            _timer.OnCooldownPassed -= SpawnRandomCharacter;
        }

        #endregion

        private void SpawnRandomCharacter()
        {
            int index = Random.Range(0, _charactersInGame.Length);
            Instantiate(_charactersInGame[index]);
        }
    }
}

