using System;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Project.Scripts.DataExtensions;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.UI.DrawUI;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class CrowdMansLayout : MonoBehaviour
    {
        [SerializeField] private CrowdSplineFollower _crowdSplineFollower;
        [SerializeField] private CrowdMansPool _crowdMans;
        [SerializeField] private float _xScaleCof;
        [SerializeField] private float _yScaleCof;
        private bool _initialized;
        private bool _enabled;
        private IDrawInput _drawInput;

        public void Construct(IDrawInput drawInput)
        {
            _drawInput = drawInput;
            _initialized = true;
        }

        public void Enable()
        {
            _enabled = true;
            _drawInput.SomethingDrawn += RecalculateLayout;
        }

        public void Disable()
        {
            _enabled = false;
            _drawInput.SomethingDrawn -= RecalculateLayout;
        }

        public void RecalculateLayout(Vector3[] verticalPoses)
        {
            List<ManFacade> movers = _crowdMans.GetMans();
            Vector3[] offsets = ArrayPrune.PruneArray(verticalPoses, movers.Count);
            for (int i = 0; i < movers.Count; i++)
            {
                movers[i].Mover.ForwardOffset = offsets[i].y;
                movers[i].Mover.SideOffset = offsets[i].x;
            }
        }

        public void AddMan(ManMove newMan, ManMove collisioned = null)
        {
            if (collisioned == null)
            {
                newMan.ForwardOffset = 0;
                newMan.SideOffset = 0;
                return;
            }

            newMan.ForwardOffset = collisioned.ForwardOffset;
            newMan.SideOffset = collisioned.SideOffset;
        }

        private void FixedUpdate()
        {
            if (_enabled && _initialized)
                MoveMans();
        }

        private void MoveMans()
        {
            SplineComputer computer = _crowdSplineFollower.GetSpline();
            float progress = _crowdSplineFollower.GetProgress();
            List<ManFacade> mover = _crowdMans.GetMans();

            for (int i = 0; i < mover.Count; i++)
            {
                double roadLength = computer.CalculateLength();
                double progressDelta = _yScaleCof * mover[i].Mover.ForwardOffset / roadLength;
                SplineSample point = computer.Evaluate((double)progress + (double)progressDelta);
                Vector3 moverForward = point.forward;
                Vector3 moverPos = point.position + point.up * 0.1f +
                                   point.right * _xScaleCof * mover[i].Mover.SideOffset;
                mover[i].Mover.SetPos(moverPos, moverForward);
            }
        }
    }
}