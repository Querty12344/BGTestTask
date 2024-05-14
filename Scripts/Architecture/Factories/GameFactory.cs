using Dreamteck.Splines;
using Project.Scripts.Architecture.AssetsManagement;
using Project.Scripts.GamePlay;
using Project.Scripts.GamePlay.ScenePressets;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.UI.DrawUI;
using UnityEngine;

namespace Project.Scripts.Architecture.Factories
{
    class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStartPlayLister _startListener;
        private readonly IPlayerWin _playerWin;
        private readonly IPlayerLose _playerLose;
        private SceneInfoHandler _levelPressets;
        private IStaticDataProvider _staticDataProvider;
        private CrowdFacade _crowdFacade;

        public GameFactory(IAssetProvider assets, IStartPlayLister startListener, IPlayerLose playerLose,
            IPlayerWin playerWin, IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            _assets = assets;
            _startListener = startListener;
            _playerLose = playerLose;
            _playerWin = playerWin;
        }

        public void InitOnScene()
        {
            _crowdFacade = null;
            _levelPressets = GameObject.FindObjectOfType<SceneInfoHandler>();
        }

        public CrowdFacade CreateCrowd(IDrawInput drawInput)
        {
            CrowdFacade prefab = _assets.GetCrowd();
            CrowdFacade crowdFacade = Object.Instantiate(prefab, _levelPressets.crowPos.position, Quaternion.identity);
            crowdFacade.Init(_startListener, _playerLose, _playerWin, _levelPressets.crowPos.position);
            crowdFacade.GetComponent<CrowdSplineFollower>()
                .Construct(_levelPressets.road, _staticDataProvider.GetCrowdSettings());
            crowdFacade.GetComponent<CrowdMansLayout>().Construct(drawInput);
            var pool = crowdFacade.GetComponent<CrowdMansPool>();
            pool.Construct();
            for (int i = 0; i < _staticDataProvider.GetCrowdSettings().StartCount; i++)
            {
                CreateMan(crowdFacade.transform.position, pool);
            }

            _crowdFacade = crowdFacade;
            _levelPressets.CameraMover.Init(_crowdFacade.transform);
            return crowdFacade;
        }

        private ManFacade CreateMan(Vector3 at, CrowdMansPool pool)
        {
            ManFacade prefab = _assets.GetMan();
            ManFacade manFacade = Object.Instantiate(prefab, at, Quaternion.identity);
            manFacade.GetComponent<ManToCrowdConnector>().SetCrowd(pool);
            manFacade.GetComponent<ManAnimator>().Construct();
            return manFacade;
        }

        public void RebuildCrowd()
        {
            _crowdFacade.Init(_startListener, _playerLose, _playerWin, _levelPressets.crowPos.position);
            var pool = _crowdFacade.GetComponent<CrowdMansPool>();
            pool.Construct();
            CreateMan(_crowdFacade.transform.position, pool);
            _levelPressets.CameraMover.Init(_crowdFacade.transform);
        }
    }
}