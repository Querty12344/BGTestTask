using UnityEngine;

namespace Project.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "CrowdMoveSettings", fileName = "CrowdMoveSettings")]
    public class CrowdMoveSettings : ScriptableObject
    {
        public int StartCount = 15;
    }
}