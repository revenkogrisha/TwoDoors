using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Installers
{
    public class GamePauseInstaller : MonoInstaller
    {
        [SerializeField] private GamePause _pause;

        public override void InstallBindings()
        {
            Container
                .Bind<GamePause>()
                .FromInstance(_pause)
                .AsSingle()
                .NonLazy();
        }
    }
}