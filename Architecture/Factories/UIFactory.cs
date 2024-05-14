using System;
using Project.Scripts.Architecture.AssetsManagement;
using Project.Scripts.GamePlay.ScenePressets;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Windows;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Architecture.Factories
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;
        private Action _moveNextlevel;
        private Action _replay;

        public UIFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public void Init(Action moveNextLevel, Action replay)
        {
            _replay = replay;
            _moveNextlevel = moveNextLevel;
        }

        public HUDWindow CreateHUD()
        {
            return GameObject.Instantiate(_assetProvider.GetHUDWindow());
        }

        public LoseWindow CreateLoseInterface()
        {
            LoseWindow loseWindow = GameObject.Instantiate(_assetProvider.GetLoseWindow());
            loseWindow.Construct(_replay);
            return loseWindow;
        }

        public WinWindow CreateWinInterface()
        {
            WinWindow winWindow = GameObject.Instantiate(_assetProvider.GetWinWindow());
            winWindow.Construct(_moveNextlevel);
            return winWindow;
        }

        public IDrawInput CreateDrawCanvas()
        {
            SceneInfoHandler levelPressets = GameObject.FindObjectOfType<SceneInfoHandler>();
            DrawCanvas canvas = GameObject.Instantiate(_assetProvider.GetDrawCanvas(),
                levelPressets.DrawCanvasRoot.position, Quaternion.identity);
            canvas.transform.localScale = levelPressets.DrawCanvasRoot.localScale;
            canvas.transform.SetParent(levelPressets.DrawCanvasRoot);
            canvas.Construct(_container.Resolve<IStartPlayLister>(), _container.Resolve<IPlayerLose>(),
                _container.Resolve<IPlayerWin>());
            return canvas;
        }
    }
}