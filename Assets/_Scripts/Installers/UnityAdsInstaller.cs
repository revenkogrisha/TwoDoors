using UnityEngine;
using Zenject;
using TwoDoors.Ads;

namespace TwoDoors.Installers
{
    public class UnityAdsInstaller : MonoInstaller
    {
        [SerializeField] private UnityAds _adsPrefab;

        public override void InstallBindings()
        {
            var adInstance = Container.InstantiatePrefabForComponent<UnityAds>(
                _adsPrefab, Vector3.zero, Quaternion.identity, null);

            Container.Bind<UnityAds>()
                .FromInstance(adInstance)
                .AsSingle()
                .NonLazy();
        }
    }
}