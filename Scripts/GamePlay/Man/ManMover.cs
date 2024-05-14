using System;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class ManMove : MonoBehaviour
    {
        [SerializeField] private ManAnimator _animator;
        public float ForwardOffset;
        public float SideOffset;
        [SerializeField] private Vector3 _targetPosition;
        private bool _canMove = true;

        public void Init()
        {
            _animator.PlayRun();
        }

        public void SetPos(Vector3 moverPos, Vector3 moverForward)
        {
            _targetPosition = moverPos;
            transform.forward = moverForward;
        }

        private void FixedUpdate()
        {
            if (_targetPosition != Vector3.zero && _canMove)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPosition, 0.3f);
            }
        }

        public void Stop()
        {
            _canMove = false;
        }
    }
}