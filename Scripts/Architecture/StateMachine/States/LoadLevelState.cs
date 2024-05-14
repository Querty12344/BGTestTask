using Dreamteck.Splines;
using Project.Scripts.Architecture.Factories;
using Project.Scripts.Architecture.LoadingCurtain;
using Project.Scripts.Architecture.SceneLoading;
using Project.Scripts.GamePlay;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.UI.DrawUI;
using Project.Scripts.UI.Services;

namespace Project.Scripts.StateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IUIService _uiService;
        private readonly ISceneLoader _sceneLoader;
        private IStateMachine _stateMachine;
        private readonly IPlayerWin _playerWin;
        private readonly IPlayerLose _playerLose;

        public LoadLevelState(IUIService uiService, IGameFactory gameFactory, ISceneLoader sceneLoader
            , IPlayerLose playerLose, IPlayerWin playerWin)
        {
            _playerLose = playerLose;
            _playerWin = playerWin;
            _uiService = uiService;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _sceneLoader.Load(SceneNames.GameSceneName, InitLevel);
        }

        private void InitLevel()
        {
            _gameFactory.InitOnScene();
            IDrawInput input = _uiService.CreateGameUI();
            CrowdFacade crowd = _gameFactory.CreateCrowd(input);
            _playerLose.Init(crowd);
            _playerWin.Init(crowd);
            MoveNextState();
        }

        private void MoveNextState()
        {
            _stateMachine.EnterState<GameLoopState>();
        }
    }
}