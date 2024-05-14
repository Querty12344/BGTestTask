using System;
using UnityEngine;

namespace Project.Scripts.GamePlay.RoadObstacles
{
    public class DeathTrigger : MonoBehaviour
    {
        public bool Enabled = true;

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}