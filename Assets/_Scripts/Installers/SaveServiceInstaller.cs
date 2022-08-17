using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.Installers
{
    public class SaveServiceInstaller : MonoInstaller
    {
        [SerializeField] private SaveService _saveServicePrefab;

        public override void InstallBindings()
        {
            var saveInstance = Container.InstantiatePrefabForComponent<SaveService>(
                _saveServicePrefab, Vector3.zero, Quaternion.identity, null);

            Container.Bind<SaveService>()
                .FromInstance(saveInstance)
                .AsSingle()
                .NonLazy();
        }
    }
}