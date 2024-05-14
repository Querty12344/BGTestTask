using System;
using Dreamteck.Splines;
using Project.Scripts.StaticData;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class CrowdSplineFollower : MonoBehaviour
    {
        [SerializeField] private SplineFollower _splineFollower;
        private bool _initialized;
        private bool _enabled;
        private SplineComputer _splineComputer;
        private CrowdMoveSettings _moveSettings;
        public event Action Finished;

        public void Construct(SplineComputer splineComputer, CrowdMoveSettings moveSettings)
        {
            _moveSettings = moveSettings;
            _splineComputer = splineComputer;
            _splineFollower.spline = _splineComputer;
            _splineFollower.enabled = false;
            _initialized = true;
        }


        public void Enable()
        {
            _enabled = true;
            _splineFollower.onEndReached += OnFinish;
            _splineFollower.enabled = true;
            _splineFollower.Restart();
            _splineFollower.autoUpdate = true;
        }

        public void Disable()
        {
            _splineFollower.onEndReached -= OnFinish;
            _splineFollower.enabled = false;
            _enabled = false;
        }


        public float GetProgress()
        {
            return (float)_splineFollower.GetPercent();
        }

        public SplineComputer GetSpline()
        {
            return _splineComputer;
        }

        private void OnFinish(double progress)
        {
            Finished?.Invoke();
        }

        public void GetStart(Vector3 start)
        {
            transform.position = start;
        }
    }
}