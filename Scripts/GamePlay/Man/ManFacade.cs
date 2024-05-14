using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class ManFacade : MonoBehaviour
    {
        public ManMove Mover;
        public ManDeath ManDeath;
        public ManToCrowdConnector Connector;

        public CrowdMansPool GetCrowdPool()
        {
            return Connector.GetCrowdPool();
        }

        public void RemoveForTime(float time)
        {
            StartCoroutine(WaitForDeath(time));
        }

        private IEnumerator WaitForDeath(float time)
        {
            yield return new WaitForSeconds(time);
            if (this != null)
                Destroy(gameObject);
        }
    }
}