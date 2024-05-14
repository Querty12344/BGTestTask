using System;
using Project.Scripts.UI.Elements;
using Project.Scripts.UI.Services;

namespace Project.Scripts.GamePlay.WinLoseManagement
{
    public class StartPlayLister : IStartPlayLister
    {
        private StartGameButton _startGameButton;
        private bool _isListening;


        public void Init(IUIService uiService)
        {
            _startGameButton = uiService.GetStartButton();
            _startGameButton.gameObject.SetActive(true);
            _startGameButton.GameStarted += OnStartGameButtonClicked;
        }

        public event Action GameStarted;

        public void StartListen()
        {
            _isListening = true;
        }

        private void OnStartGameButtonClicked()
        {
            if (!_isListening)
            {
                return;
            }

            GameStarted?.Invoke();
            _isListening = false;
            _startGameButton.GameStarted -= OnStartGameButtonClicked;
            _startGameButton.gameObject.SetActive(false);
        }
    }
}