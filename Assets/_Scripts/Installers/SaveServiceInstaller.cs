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
            Container.Bind<SaveService>()
                .FromInstance(_saveService)
                .AsSingle()
                .NonLazy();
        }
    }
}