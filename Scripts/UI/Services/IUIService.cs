using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Elements;

namespace Project.Scripts.UI.Services
{
    public interface IUIService
    {
        public void Cleanup();
        public IDrawInput CreateGameUI();
        public void Lose();
        public void Win();
        StartGameButton GetStartButton();
    }
}