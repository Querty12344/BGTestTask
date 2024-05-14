using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Windows
{
    public class WinWindow : MonoBehaviour
    {
        [SerializeField] private Button _moveNext;
        private Action _moveNextLevel;

        public void Remove()
        {
            Destroy(gameObject);
        }

        public void Construct(Action moveNextLevel)
        {
            _moveNextLevel = moveNextLevel;
            _moveNext.onClick.AddListener(MoveNextLevel);
        }

        private void MoveNextLevel()
        {
            _moveNext.onClick.RemoveListener(MoveNextLevel);
            _moveNextLevel?.Invoke();
            _moveNextLevel = null;
        }
    }
}