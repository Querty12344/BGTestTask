using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Elements
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public event Action GameStarted;

        private void Awake()
        {
            _button.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            GameStarted?.Invoke();
        }
    }
}