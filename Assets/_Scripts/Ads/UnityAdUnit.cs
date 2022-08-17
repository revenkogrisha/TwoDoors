using UnityEngine;
using UnityEngine.Advertisements;

namespace TwoDoors.Ads
{
    public abstract class UnityAdUnit : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        protected abstract string AndroidAdUnitId { get; }

        protected string CurrentAdUnitId;
        private int _adShowPercentChance = 40;

        private void Awake()
        {
#if UNITY_ANDROID
            CurrentAdUnitId = AndroidAdUnitId;
#endif

            Load();
        }

        public void ShowWithChance()
        {
            Tools.InvokeWithChance(_adShowPercentChance, Show);
        }

        public void Show()
        {
            Advertisement.Show(CurrentAdUnitId, this);
        }

        private void Load()
        {
            Advertisement.Load(CurrentAdUnitId, this);
        }

        public virtual void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            Load();
        }

        public virtual void OnUnityAdsAdLoaded(string placementId) { }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

        public void OnUnityAdsShowClick(string placementId) { }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

        public void OnUnityAdsShowStart(string placementId) { }
    }
}