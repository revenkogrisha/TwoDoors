using UnityEngine;
using Zenject;

namespace TwoDoors.Scene
{
    [RequireComponent(typeof(Animator))]
    public class BossAnimator : MonoBehaviour
    {
        private const string IsTriggered = nameof(IsTriggered);
        private const string IsTriggerEnded = nameof(IsTriggerEnded);

        [Inject] private Score _score;

        private Animator _animator;
        private int _isTriggeredId;
        private int _isTriggerEndedId;

        #region MonoBehaviour

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _isTriggeredId = Animator.StringToHash(IsTriggered);
            _isTriggerEndedId = Animator.StringToHash(IsTriggerEnded);
        }

        private void OnEnable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnPlayerFailed += StartPunishment;
        }

        private void OnDisable()
        {
            if (_score is LevelScore levelScore)
                levelScore.OnPlayerFailed -= StartPunishment;
        }

        #endregion

        private void StartPunishment() => _animator.SetTrigger(_isTriggeredId);

        private void EndPunishment() => _animator.SetTrigger(_isTriggerEndedId);
    }
}