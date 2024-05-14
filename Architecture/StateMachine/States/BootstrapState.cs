using Project.Scripts.Architecture.AssetsManagement;
using Project.Scripts.Architecture.SceneLoading;
using Project.Scripts.StateMachine;
using Project.Scripts.StateMachine.States;

public class BootstrapState : IState
{
    private readonly IAssetProvider _assetProvider;
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly ISceneLoader _sceneLoader;
    private IStateMachine _stateMachine;

    public BootstrapState(ISceneLoader sceneLoader, IStaticDataProvider staticDataProvider,
        IAssetProvider assetProvider)
    {
        _sceneLoader = sceneLoader;
        _staticDataProvider = staticDataProvider;
        _assetProvider = assetProvider;
    }

    public void Enter(IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _sceneLoader.Load(SceneNames.BootSceneName, LoadResources);
    }

    private void LoadResources()
    {
        _staticDataProvider.Load();
        _assetProvider.LoadAssets();
        MoveNextState();
    }

    private void MoveNextState()
    {
        _stateMachine.EnterState<LoadLevelState>();
    }
}