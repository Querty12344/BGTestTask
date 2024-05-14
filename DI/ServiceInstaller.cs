using Project.Scripts.Architecture.AssetsManagement;
using Project.Scripts.Architecture.Bootstrap;
using Project.Scripts.Architecture.Factories;
using Project.Scripts.Architecture.LoadingCurtain;
using Project.Scripts.Architecture.Progress;
using Project.Scripts.Architecture.SceneLoading;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.StateMachine;
using Project.Scripts.StateMachine.States;
using Project.Scripts.UI.Services;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Project.Scripts.DI
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private Bootstrap _bootstrap;
        [SerializeField] private Curtain _curtain;

        public override void InstallBindings()
        {
            BindCurtain();
            BindDataManagement();
            BindFactories();
            BindStates();
            BindWinLoseManagment();
            BindUI();
            BindMainLogic();
        }

        private void BindCurtain()
        {
            Container.Bind<Curtain>().FromInstance(_curtain).AsSingle();
        }

        private void BindDataManagement()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle();
            Container.Bind<IPlayerProgress>().To<PlayerProgress>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
        }

        private void BindWinLoseManagment()
        {
            Container.Bind<IStartPlayLister>().To<StartPlayLister>().AsSingle();
            Container.Bind<IPlayerLose>().To<PlayerLose>().AsSingle();
            Container.Bind<IPlayerWin>().To<PlayerWin>().AsSingle();
        }

        private void BindMainLogic()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(_bootstrap).AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine.StateMachine>().AsSingle();
        }

        private void BindUI()
        {
            Container.Bind<IUIService>().To<UIService>().AsSingle();
        }
    }
}