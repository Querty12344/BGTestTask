using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Windows
{
    public class LoseWindow : MonoBehaviour
    {
        private Action _replay;
        [SerializeField] private Button _buttonReplay;

        public void Remove()
        {
            Destroy(gameObject);
        }


        public void Construct(Action replay)
        {
            _replay = replay;
            _buttonReplay.onClick.AddListener(Replay);
        }

        private void Replay()
        {
            _buttonReplay.onClick.RemoveListener(Replay);
            _replay?.Invoke();
            _replay = null;
        }
    }
}