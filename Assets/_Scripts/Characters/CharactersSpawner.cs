using TwoDoors.Characters.Moveable;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Timer))]
    public class CharactersSpawner : MonoBehaviour
    {
        [SerializeField] private Movement[] _charactersInGame;
        [SerializeField] private MovementData _data;

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
            var item = _charactersInGame[index];
            var character = _container.InstantiatePrefab(item);
            var movement = character.GetComponent<Movement>();

            movement.InitData(_data);
        }
    }
}

