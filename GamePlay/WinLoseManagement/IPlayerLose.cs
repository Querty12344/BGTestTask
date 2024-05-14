using System;

namespace Project.Scripts.GamePlay.WinLoseManagement
{
    public interface IPlayerLose
    {
        public void Init(CrowdFacade crowd);
        public event Action Lose;
    }
}