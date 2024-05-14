using System;
using Project.Scripts.UI.Services;

namespace Project.Scripts.GamePlay.WinLoseManagement
{
    public interface IStartPlayLister
    {
        public void Init(IUIService uiService);
        public event Action GameStarted;
        public void StartListen();
    }
}