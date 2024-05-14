using System;
using Project.Scripts.GamePlay.WinLoseManagement;
using Project.Scripts.UI.Elements;
using UnityEngine;

namespace Project.Scripts.UI.DrawUI
{
    public class DrawCanvas : MonoBehaviour, IDrawInput
    {
        public event Action<Vector3[]> SomethingDrawn;
        [SerializeField] private DrawInput _drawInput;
        private bool _enabled;
        private IStartPlayLister _startPlayLister;
        private IPlayerLose _playerLose;
        private IPlayerWin _playerWin;

        public void Construct(IStartPlayLister startPlayLister, IPlayerLose playerLose, IPlayerWin playerWin)
        {
            _playerWin = playerWin;
            _playerLose = playerLose;
            _startPlayLister = startPlayLister;
            _startPlayLister.GameStarted += Enable;
            _playerLose.Lose += Disable;
            _playerWin.WinLevel += Disable;
        }

        private void Enable()
        {
            _startPlayLister.GameStarted -= Enable;
            _enabled = true;
            _drawInput.Enable();
            _drawInput.PictureFinished += OnPictureFinished;
        }

        private void Disable()
        {
            _playerLose.Lose -= Disable;
            _playerWin.WinLevel -= Disable;
            _enabled = false;
            _drawInput.PictureFinished -= OnPictureFinished;
            _drawInput.Disable();
            gameObject.SetActive(false);
        }

        private void OnPictureFinished(Vector3[] points)
        {
            if (_enabled)
            {
                SomethingDrawn?.Invoke(points);
            }
        }
    }
}