using System;
using Dreamteck.Splines;
using UnityEngine;

namespace Project.Scripts.GamePlay.CameraLogic
{
    public class CameraMover : MonoBehaviour
    {
        private bool _inited;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _lerp;
        [SerializeField] private Transform _target;
        [SerializeField] private SplineComputer _splineComputer;

        public void Init(Transform crowd)
        {
            _inited = true;
            _target = crowd;
        }

        private void FixedUpdate()
        {
            if (_inited && _target != null)
            {
                transform.position = Vector3.Lerp(transform.position,
                    _splineComputer.Project(_target.position + _offset).position, _lerp);
                transform.LookAt(_target);
            }
        }
    }
}