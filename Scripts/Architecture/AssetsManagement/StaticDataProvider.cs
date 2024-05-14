using Project.Scripts.StaticData;
using UnityEngine;

namespace Project.Scripts.Architecture.AssetsManagement
{
    class StaticDataProvider : IStaticDataProvider
    {
        private CrowdMoveSettings _crowdMoveSettings;

        public void Load()
        {
            _crowdMoveSettings = Resources.Load<CrowdMoveSettings>(AssetPath.CrowdPath);
        }

        public CrowdMoveSettings GetCrowdSettings()
        {
            return _crowdMoveSettings;
        }
    }
}