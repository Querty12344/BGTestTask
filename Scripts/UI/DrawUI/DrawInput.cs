using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class DrawInput : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _minDistance;
        [SerializeField] private Transform _empty;
        private List<Transform> _drawDots = new List<Transform>();
        private Vector3 _previousPosition;
        private List<Vector3> _dots = new List<Vector3>();
        private bool _enabled;
        public event Action<Vector3[]> PictureFinished;

        public void Enable()
        {
            _enabled = true;
            _previousPosition = transform.position;
        }

        public void Disable()
        {
            _enabled = false;
            _previousPosition = transform.position;
        }

        public void OnMouseExit()
        {
            ClearCanvas();
        }

        private Vector3 GetMouseWorldPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 6;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                return hit.point;
            return Vector3.zero;
        }

        private void Update()
        {
            if (!_enabled)
                return;
            if (Input.GetMouseButton(0))
            {
                Vector3 currentPosition = GetMouseWorldPosition();
                if (Vector3.Distance(currentPosition, _previousPosition) > _minDistance)
                {
                    DrawPoint(currentPosition);
                }
            }
            else
            {
                ClearCanvas();
            }
        }

        private void DrawPoint(Vector3 currentPosition)
        {
            if (_previousPosition == transform.position)
            {
                _lineRenderer.positionCount++;

                Transform next = Instantiate(_empty, currentPosition, Quaternion.identity);
                next.SetParent(transform);
                _drawDots.Add(next);
                _lineRenderer.SetPosition(0, next.position);
            }
            else
            {
                _lineRenderer.positionCount++;
                Transform next = Instantiate(_empty, currentPosition, Quaternion.identity);
                next.SetParent(transform);
                _drawDots.Add(next);
                for (int i = 0; i < _lineRenderer.positionCount; i++)
                {
                    _lineRenderer.SetPosition(i, _drawDots[i].position);
                }

                _dots.Add(currentPosition - transform.position);
            }

            _previousPosition = currentPosition;
        }

        private void ClearCanvas()
        {
            if (_lineRenderer.positionCount > 3 && _dots.Count > 3)
            {
                PictureFinished?.Invoke(_dots.ToArray());
            }

            _dots.Clear();
            _lineRenderer.positionCount = 0;
            foreach (var drawDot in _drawDots)
            {
                Destroy(drawDot.gameObject);
            }

            _drawDots.Clear();
            _previousPosition = transform.position;
        }
    }
}