using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.Installers
{
    public class SaveServiceInstaller : MonoInstaller
    {
        [SerializeField] private SaveService _saveService;

        public override void InstallBindings()
        {
            var saveInstance = Container
                .InstantiatePrefabForComponent<SaveService>(
                _saveService, new Vector3(), Quaternion.identity, null);

            Container.Bind<SaveService>()
                .FromInstance(saveInstance)
                .AsSingle()
                .NonLazy();
        }
    }
}