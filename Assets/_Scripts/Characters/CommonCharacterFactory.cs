using System.Collections.Generic;
using UnityEngine;

namespace TwoDoors.Characters
{
    [DisallowMultipleComponent]
    public class CommonCharacterFactory : CharacterFactory
    {
        [SerializeField] private GameObject[] _charactersPrefabs;

        private Dictionary<CharactersId, GameObject> _characters;

        #region MonoBehaviour

        private void Awake()
        {
            _characters = new Dictionary<CharactersId, GameObject>();

            foreach (var item in _charactersPrefabs)
            {
                var character = item.GetComponent<Character>();
                var id = character.Id;

                _characters.Add(id, item);
            }
        }

        #endregion

        public override GameObject GetCharacter(CharactersId id)
        {
            return _characters[id];
        }
    }
}
