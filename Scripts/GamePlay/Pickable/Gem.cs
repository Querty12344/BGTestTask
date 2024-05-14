using System;
using UnityEngine;

namespace Project.Scripts.GamePlay.Pickable
{
    public class Gem : MonoBehaviour
    {
        [SerializeField] private GameObject _pickFX;
        [SerializeField] private Animator _pickAnimation;
        [SerializeField] private bool _activaeted;

        private void OnTriggerEnter(Collider other)
        {
            if (_activaeted)
                return;
            if (other.TryGetComponent<ManFacade>(out var man))
            {
                _activaeted = true;
                Instantiate(_pickFX, transform.position, Quaternion.identity);
                _pickAnimation.SetBool("Picked", true);
                Destroy(gameObject, 1f);
            }
        }
    }
}