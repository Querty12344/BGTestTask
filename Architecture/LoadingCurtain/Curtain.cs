using System;
using UnityEngine;

namespace Project.Scripts.Architecture.LoadingCurtain
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtainCanvas;
        [SerializeField] private float _fadeSpeed;
        private bool Hiding;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Hide()
        {
            Hiding = true;
        }

        public void Show()
        {
            Hiding = true;
        }

        private void FixedUpdate()
        {
            if (Hiding)
            {
                if (_curtainCanvas.alpha > 0.1f)
                {
                    _curtainCanvas.alpha -= _fadeSpeed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                gameObject.SetActive(true);
                _curtainCanvas.alpha = 1;
            }
        }
    }
}