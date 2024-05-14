using Project.Scripts.Architecture.Factories;
using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Elements;
using Project.Scripts.UI.Windows;

namespace Project.Scripts.UI.Services
{
    class UIService : IUIService
    {
        private HUDWindow _hudWindow;
        private WinWindow _winWindow;
        private LoseWindow _loseWindow;
        private DrawCanvas _drawCanvas;
        private readonly IUIFactory _uiFactory;

        public UIService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Cleanup()
        {
            _hudWindow.Remove();
            _winWindow.Remove();
            _loseWindow.Remove();
        }

        public IDrawInput CreateGameUI()
        {
            _hudWindow = _uiFactory.CreateHUD();
            return _uiFactory.CreateDrawCanvas();
        }

        public void Lose()
        {
            _uiFactory.CreateLoseInterface();
        }

        public void Win()
        {
            _uiFactory.CreateWinInterface();
        }

        public StartGameButton GetStartButton()
        {
            return _hudWindow.StartButton();
        }
    }
}