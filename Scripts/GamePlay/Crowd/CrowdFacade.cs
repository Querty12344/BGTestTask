using System;
using Project.Scripts.GamePlay.WinLoseManagement;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class CrowdFacade : MonoBehaviour
    {
        public event Action Lose;
        [SerializeField] private CrowdMansLayout _layout;
        [SerializeField] private CrowdMansPool _pool;
        [SerializeField] private CrowdSplineFollower _follower;
        private IPlayerLose _lose;
        private IPlayerWin _win;
        private IStartPlayLister _startPlayLister;

        public void Init(IStartPlayLister startPlayLister, IPlayerLose lose, IPlayerWin win, Vector3 startPos)
        {
            _startPlayLister = startPlayLister;
            _win = win;
            _lose = lose;
            _follower.GetStart(startPos);
            startPlayLister.GameStarted += EnableComponents;
            lose.Lose += DisableComponents;
            win.WinLevel += DisableComponents;
        }

        private void EnableComponents()
        {
            _startPlayLister.GameStarted -= EnableComponents;
            _lose.Lose -= DisableComponents;
            _win.WinLevel -= DisableComponents;
            _pool.Enable();
            _layout.Enable();
            _follower.Enable();
        }

        private void DisableComponents()
        {
            _startPlayLister.GameStarted -= EnableComponents;
            _lose.Lose -= DisableComponents;
            _win.WinLevel -= DisableComponents;
            _pool.Disable();
            _layout.Disable();
            _follower.Disable();
        }
    }
}