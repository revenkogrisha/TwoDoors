using TwoDoors.Ads;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.GUI.Buttons
{
    public class AdContinueButton : UIButton
    {
        [SerializeField] private RewardedAd _rewardedAd;
        [SerializeField] private GameObject _toClose;

        [Inject] private GamePause _pause;

        private int _disappearPercentChance = 60;

        protected void Awake()
        {
            base.Awake();
            Tools.InvokeWithChance(_disappearPercentChance, Disappear);
        }

        protected void OnEnable()
        {
            base.OnEnable();
            _rewardedAd.OnAdLoaded += ActivateButton;
            _rewardedAd.OnAdWatched += ContinueGame;
        }

        protected void OnDisable()
        {
            base.OnDisable();
            _rewardedAd.OnAdLoaded -= ActivateButton;
            _rewardedAd.OnAdWatched -= ContinueGame;
        }

        protected override void OnClicked()
        {
            _rewardedAd.Show();
        }

        private void ActivateButton() => Button.interactable = true;

        private void ContinueGame()
        {
            if (_toClose != null)
                _toClose.SetActive(false);

            _pause.ContinueTimeFlow();
            Disappear();
        }

        private void Disappear() => gameObject.SetActive(false);
    }
}