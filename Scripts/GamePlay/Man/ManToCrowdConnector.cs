using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class ManToCrowdConnector : MonoBehaviour
    {
        private CrowdMansPool _mansPool;
        [SerializeField] private ManFacade _manFacade;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<ManFacade>(out var manFacade) && _mansPool == null)
            {
                _mansPool = manFacade.GetCrowdPool();
                _mansPool.AddMan(_manFacade, manFacade.Mover);
            }
        }

        public CrowdMansPool GetCrowdPool()
        {
            return _mansPool;
        }

        public void SetCrowd(CrowdMansPool mansPool)
        {
            _mansPool = mansPool;
            _mansPool.AddMan(_manFacade);
        }
    }
}