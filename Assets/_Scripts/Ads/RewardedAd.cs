using System;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

namespace TwoDoors.Ads
{
    public class RewardedAd : UnityAdUnit
    {
        protected override string AndroidAdUnitId => "Rewarded_Android";

        private int _menuSceneIndex = 0;

        public event Action OnAdLoaded;
        public event Action OnAdWatched;

        public override void OnUnityAdsAdLoaded(string placementId)
        {
            if (placementId.Equals(CurrentAdUnitId))
                OnAdLoaded?.Invoke();
        }

        public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (!showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
                SceneManager.LoadScene(_menuSceneIndex);

            OnAdWatched?.Invoke();
        }
    }
}