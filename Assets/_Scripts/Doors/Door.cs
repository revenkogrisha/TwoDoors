using System;
using System.Collections.Generic;
using TwoDoors.Characters;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Doors
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private DoorsId _id;
        [SerializeField] private List<CharactersId> _charactersWhoPasses;

        [Inject] private GameState _game;

        private DoorAnimator _doorAnimator;
        private Character _characterEntered;

        public event Action OnDoorOpened;
        public event Action OnDoorClosed;

        public bool IsCharacterEntered => _characterEntered != null;

        #region MonoBehaviour

        private void Awake()
        {
            _doorAnimator = new DoorAnimator(this, _animator);
        }

        private void OnDisable()
        {
            _doorAnimator.Disable();
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

        public void Open() => OnDoorOpened?.Invoke();

        public void Close() => OnDoorClosed?.Invoke();

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

