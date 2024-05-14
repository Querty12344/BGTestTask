using Project.Scripts.Architecture.Factories;
using Project.Scripts.Architecture.LoadingCurtain;
using Project.Scripts.Architecture.SceneLoading;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.UI.Services;
using Unity.VisualScripting;

namespace Project.Scripts.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IUIService _uiService;
        private readonly Curtain _curtain;
        private readonly IUIFactory _uiFactory;
        private IStateMachine _stateMachine;
        private IStartPlayLister _startPlayLister;

        public GameLoopState(Curtain curtain, IUIFactory uiFactory, IUIService uiService, IGameFactory gameFactory,
            IStartPlayLister startPlayLister)
        {
            _startPlayLister = startPlayLister;
            _uiFactory = uiFactory;
            _curtain = curtain;
            _uiService = uiService;
            _gameFactory = gameFactory;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _uiFactory.Init(MoveNextLevel, Replay);
            _stateMachine = stateMachine;
            _curtain.Hide();
            _startPlayLister.Init(_uiService);
            _startPlayLister.StartListen();
        }

        private void Replay()
        {
        }

        private void MoveNextLevel()
        {
        }
    }
}