using System;
using System.Threading.Tasks;
using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Windows;
using UnityEngine;

namespace Project.Scripts.Architecture.Factories
{
    public interface IUIFactory
    {
        public void Init(Action moveNextLevel, Action replay);
        public HUDWindow CreateHUD();
        public LoseWindow CreateLoseInterface();
        public WinWindow CreateWinInterface();
        IDrawInput CreateDrawCanvas();
    }
}