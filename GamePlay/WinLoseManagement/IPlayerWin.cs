using System;

namespace Project.Scripts.GamePlay.WinLoseManagement
{
    public interface IPlayerWin
    {
        public event Action WinLevel;
        public void Init(CrowdFacade facade);
    }
}