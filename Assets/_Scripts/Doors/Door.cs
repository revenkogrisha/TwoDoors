using System;
using System.Collections.Generic;
using TwoDoors.Characters;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Doors
{
    [DisallowMultipleComponent]
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private DoorsId _id;
        [SerializeField] private List<CharactersId> _charactersWhoPasses;

        [Inject] private Score _score;

        private DoorAnimator _doorAnimator;

        public event Action OnDoorOpened;
        public event Action OnDoorClosed;

        public bool IsCharacterEntered { get; private set; } = false;

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
            Router.Route<Character>(TryPassCharacter, other);
        }

        #endregion

        public void Enter(Character character)
        {
            IsCharacterEntered = true;
            OnDoorOpened?.Invoke();
        }

        public void Exit()
        {
            IsCharacterEntered = false;
            OnDoorClosed?.Invoke();
        }

        private void TryPassCharacter(Character character)
        {
            if (!character.IsTryingToPass)
                return;

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
            _score.AddScore();
        }

        private void SubtractScore()
        {
            _score.SubtractScore();
        }
    }
}

