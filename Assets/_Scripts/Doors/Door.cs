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
        [SerializeField] private AudioSource _successSound;
        [SerializeField] private AudioSource _failSound;

        [Inject] private Score _score;

        private DoorAnimator _doorAnimator;
        private DoorAudio _audio;

        public event Action OnDoorOpened;
        public event Action OnDoorClosed;

        #region MonoBehaviour

        private void Awake()
        {
            _doorAnimator = new(this, _animator);
            _audio = new(_successSound, _failSound, _score);
        }

        private void OnDisable()
        {
            _doorAnimator.Disable();
            _audio.Disable();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Tools.InvokeIfNotNull<Character>(other, TryPassCharacter);
        }

        #endregion

        public void Open()
        {
            OnDoorOpened?.Invoke();
        }

        public void Close()
        {
            OnDoorClosed?.Invoke();
        }

        private void TryPassCharacter(Character character)
        {
            if (!character.IsTryingToPass)
                return;

            if (_charactersWhoPasses.Contains(character.Id))
            {
                _score.AddScore();
                Destroy(character.gameObject);
                Close();

                return;
            }

            _score.InitFail();
            Destroy(character.gameObject);
            Close();
        }
    }
}

