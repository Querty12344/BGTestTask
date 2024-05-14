using System;
using Project.Scripts.UI.Services;

namespace Project.Scripts.GamePlay.WinLoseManagement
{
    public class PlayerLose : IPlayerLose
    {
        private readonly IUIService _uiService;
        private CrowdFacade _crowd;

        public event Action Lose;

        public PlayerLose(IUIService uiService)
        {
            _uiService = uiService;
        }

        public void Init(CrowdFacade crowd)
        {
            _crowd = crowd;
            _crowd.Lose += OnLose;
        }

        private void OnLose()
        {
            _crowd.Lose -= OnLose;
            Lose?.Invoke();
            _uiService.Lose();
        }
    }
}