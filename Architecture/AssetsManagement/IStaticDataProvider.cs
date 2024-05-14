using Project.Scripts.StaticData;
using UnityEngine.UI;

namespace Project.Scripts.Architecture.AssetsManagement
{
    public interface IStaticDataProvider
    {
        public CrowdMoveSettings GetCrowdSettings();
        void Load();
    }
}