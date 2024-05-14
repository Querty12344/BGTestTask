using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class ManAnimator : MonoBehaviour
    {
        [SerializeField] private float _dieAnimTime;
        [SerializeField] private ManFacade _manFacade;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _dieFX;
        [SerializeField] private GameObject _startRunFX;

        public void Construct()
        {
            PlayIdle();
        }

        public void PlayDeath()
        {
            Instantiate(_dieFX, transform.position, Quaternion.identity);
            _animator.SetBool(ManAnimationNames.Die, true);
            _manFacade.RemoveForTime(_dieAnimTime);
        }

        public void PlayRun()
        {
            Instantiate(_startRunFX, transform.position, transform.rotation);
            _animator.SetBool(ManAnimationNames.Run, true);
        }

        public void PlayIdle()
        {
            _animator.SetBool(ManAnimationNames.Idle, true);
        }
    }
}