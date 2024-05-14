using Dreamteck.Splines;
using Project.Scripts.GamePlay;
using Project.Scripts.GamePlay.RoadObstacles;
using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Windows;
using UnityEngine;

namespace Project.Scripts.Architecture.AssetsManagement
{
    class AssetProvider : IAssetProvider
    {
        private CrowdFacade _crowdFacade;
        private ManFacade _manFacade;
        private HUDWindow _hudWindow;
        private LoseWindow _loseWindow;
        private WinWindow _winWindow;
        private DrawCanvas _drawCanvas;

        public void LoadAssets()
        {
            _drawCanvas = Resources.Load<DrawCanvas>(AssetPath.DrawCanvasPath);
            _crowdFacade = Resources.Load<CrowdFacade>(AssetPath.CrowdPath);
            _manFacade = Resources.Load<ManFacade>(AssetPath.ManPath);
            _hudWindow = Resources.Load<HUDWindow>(AssetPath.HUDPath);
            _loseWindow = Resources.Load<LoseWindow>(AssetPath.LosePath);
            _winWindow = Resources.Load<WinWindow>(AssetPath.WinPath);
        }

        public CrowdFacade GetCrowd()
        {
            return _crowdFacade;
        }

        public ManFacade GetMan()
        {
            return _manFacade;
        }

        public HUDWindow GetHUDWindow()
        {
            return _hudWindow;
        }

        public LoseWindow GetLoseWindow()
        {
            return _loseWindow;
        }

        public WinWindow GetWinWindow()
        {
            return _winWindow;
        }


        public DrawCanvas GetDrawCanvas()
        {
            return _drawCanvas;
        }
    }
}