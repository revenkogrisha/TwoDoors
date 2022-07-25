using System;
using System.Collections.Generic;
using TwoDoors.Characters;
using TwoDoors.Data;
using TwoDoors.Scene;
using UnityEngine;

namespace TwoDoors.Doors
{
    [RequireComponent(typeof(DoorAnimator))]
    public class Door : MonoBehaviour
    {
        [SerializeField] private DoorsId _id;
        [SerializeField] private GameState _game;
        [SerializeField] private List<CharactersId> _charactersWhoPasses;

        private Character _characterEntered;
        private DoorAnimator _doorAnimator;
        private Character _character;

        public bool IsCharacterEntered => _characterEntered != null;

        #region MonoBehaviour

        private void Awake()
        {
            _doorAnimator = GetComponent<DoorAnimator>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _character = other.GetComponent<Character>();

            if (_character == null)
                throw new Exception("Character is null!");

            if (!_character.IsTryingToPass)
                return;

            TryPassCharacter();
        }

        #endregion

        public void Open() => _doorAnimator.Open();

        public void Close() => _doorAnimator.Close();

        public void SetEnteredCharacter(Character character) => _characterEntered = character;

        public void RemoveEnteredCharacter() => _characterEntered = null;

        private void TryPassCharacter()
        {
            if (_charactersWhoPasses.Contains(_character.Id))
            {
                PassCharacter();
                return;
            }

            SubtractScore();
        }

        private void PassCharacter()
        {
            Destroy(_character.gameObject);
            _game.AddScore();
        }

        private void SubtractScore()
        {
            Destroy(_character.gameObject);
            _game.SubtractScore();
        }
    }
}

