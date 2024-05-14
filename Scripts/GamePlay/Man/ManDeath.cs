using System;
using Project.Scripts.GamePlay.RoadObstacles;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class ManDeath : MonoBehaviour
    {
        private CrowdMansPool _crowdMansPool;
        [SerializeField] private ManFacade _manFacade;
        [SerializeField] private ManAnimator _manAnimator;

        public void SetPool(CrowdMansPool crowdMansPool)
        {
            _crowdMansPool = crowdMansPool;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeathTrigger>(out var d))
            {
                _crowdMansPool.RemoveMan(_manFacade);
                _manAnimator.PlayDeath();
            }
        }

        public void Die()
        {
            _crowdMansPool.RemoveMan(_manFacade);
            _manAnimator.PlayDeath();
        }
    }
}