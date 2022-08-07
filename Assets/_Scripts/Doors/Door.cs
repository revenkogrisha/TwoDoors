using System;
using System.Collections.Generic;
using TwoDoors.Characters;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Doors
{
    [RequireComponent(typeof(DoorAnimator))]
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorsId _id;
        [SerializeField] private List<CharactersId> _charactersWhoPasses;

        [Inject] private GameState _game;

        private Character _characterEntered;
        private DoorAnimator _doorAnimator;

        public bool IsCharacterEntered => _characterEntered != null;

        #region MonoBehaviour

        private void Awake()
        {
            _doorAnimator = GetComponent<DoorAnimator>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var character = other.GetComponent<Character>();

            if (character == null)
                throw new Exception("Character is null!");

            if (character.IsTryingToPass)
                TryPassCharacter(character);
        }

        #endregion

        public void Open() => _doorAnimator.Open();

        public void Close() => _doorAnimator.Close();

        public void SetEnteredCharacter(Character character) => _characterEntered = character;

        public void RemoveEnteredCharacter() => _characterEntered = null;

        private void TryPassCharacter(Character character)
        {
            if (_charactersWhoPasses.Contains(character.Id))
            {
                AddScore();
                Destroy(character.gameObject);

                return;
            }

            SubtractScore();
            Destroy(character.gameObject);
        }

        private void AddScore()
        {
            _game.AddScore();
        }

        private void SubtractScore()
        {
            _game.SubtractScore();
        }
    }
}

