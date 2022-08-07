using Zenject;
using UnityEngine;
using TwoDoors.Scene;

namespace TwoDoors.Installers
{
    public class GameStateInstaller : MonoInstaller
    {
        [SerializeField] private GameState _gameState;

        public override void InstallBindings()
        {
            Container.Bind<GameState>()
                .FromInstance(_gameState)
                .AsSingle()
                .NonLazy();

            Container.QueueForInject(_gameState);
        }
    }
}
