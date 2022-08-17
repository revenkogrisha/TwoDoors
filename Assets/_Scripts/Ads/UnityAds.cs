using UnityEngine;
using UnityEngine.Advertisements;

namespace TwoDoors.Ads
{
    public class UnityAds : MonoBehaviour, IUnityAdsInitializationListener
    {
        private const string GameIdAndroid = "4887844";
        private const bool _testMode = true;

        [SerializeField] private InterstitialAd _interstitialAd;

        private void Awake()
        {
            Initialize();   
        }

        public void ShowInterstitialWithChance() => _interstitialAd.ShowWithChance();

        public void OnInitializationComplete() { }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }

        private void Initialize()
        {
#if UNITY_ANDROID
            Advertisement.Initialize(GameIdAndroid, _testMode, this);
#endif
        }
    }
}
