using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Timer))]
    public class CharactersSpawner : MonoBehaviour
    {
        [SerializeField] private Character[] _charactersInGame;

        [Inject] private DiContainer _container;

        private Timer _timer;

        #region MonoBehaviour

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
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
            var characterObject = _charactersInGame[index];

            _container.InstantiatePrefab(characterObject);
        }
    }
}

