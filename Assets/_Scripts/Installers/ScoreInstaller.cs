using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.Installers
{
    public class ScoreInstaller : MonoInstaller
    {
        [SerializeField] private Score _score;

        public override void InstallBindings()
        {
            Container.Bind<Score>().FromInstance(_score).AsSingle().NonLazy();
        }
    }
}