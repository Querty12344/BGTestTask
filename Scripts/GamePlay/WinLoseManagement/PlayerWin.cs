using System;
using Project.Scripts.UI.Services;
using Unity.VisualScripting;

namespace Project.Scripts.GamePlay.WinLoseManagement
{
    class PlayerWin : IPlayerWin
    {
        private readonly IUIService _uiService;
        private CrowdFacade _facade;
        public event Action WinLevel;

        public PlayerWin(IUIService uiService)
        {
            _uiService = uiService;
        }

        public void Init(CrowdFacade facade)
        {
            _facade = facade;
            facade.GetComponent<CrowdSplineFollower>().Finished += Win;
        }

        private void Win()
        {
            _facade.GetComponent<CrowdSplineFollower>().Finished -= Win;
            _uiService.Win();
            WinLevel?.Invoke();
        }
    }
}