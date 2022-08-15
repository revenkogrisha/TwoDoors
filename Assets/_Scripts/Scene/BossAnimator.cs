using UnityEngine;
using Zenject;

namespace TwoDoors.Scene
{
    [RequireComponent(typeof(Animator))]
    public class BossAnimator : MonoBehaviour
    {
        private const string IsTriggered = nameof(IsTriggered);

        [Inject] private Score _score;

        private Animator _animator;
        private int _isTriggeredId;

        #region MonoBehaviour

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _isTriggeredId = Animator.StringToHash(IsTriggered);
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

        private void StartPunishment() => _animator.SetBool(_isTriggeredId, true);

        private void EndPunishment() => _animator.SetBool(_isTriggeredId, false);
    }
}