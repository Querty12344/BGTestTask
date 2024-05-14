using Dreamteck.Splines;
using Project.Scripts.GamePlay.CameraLogic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.GamePlay.ScenePressets
{
    public class SceneInfoHandler : MonoBehaviour
    {
        public Transform DrawCanvasRoot;
        public CameraMover CameraMover;
        public SplineComputer road;
        public Transform crowPos;
    }
}