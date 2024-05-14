using Dreamteck.Splines;
using Project.Scripts.GamePlay;
using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Architecture.AssetsManagement
{
    public interface IAssetProvider
    {
        public void LoadAssets();
        public CrowdFacade GetCrowd();
        public ManFacade GetMan();
        public HUDWindow GetHUDWindow();
        public LoseWindow GetLoseWindow();
        public WinWindow GetWinWindow();
        public DrawCanvas GetDrawCanvas();
    }
}