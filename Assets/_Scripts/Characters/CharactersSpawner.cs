using TwoDoors.Data;
using UnityEngine;

namespace TwoDoors.Characters
{
    [RequireComponent(typeof(Timer))]
    public class CharactersSpawner : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private CharactersId[] _charactersInGame;

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
            var id = _charactersInGame[index];
            var characterObject = _characterFactory.GetCharacter(id);

            Instantiate(characterObject);
        }
    }
}

