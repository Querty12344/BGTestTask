using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.GamePlay.RoadObstacles
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _force;
        [SerializeField] private GameObject _bombFX;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ManFacade>(out var man))
            {
                Instantiate(_bombFX, transform.position, Quaternion.identity);
                Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

                foreach (Collider col in colliders)
                {
                    if (col.TryGetComponent<ManFacade>(out var man2))
                    {
                        man2.GetComponent<Rigidbody>().AddForce(_force * (man.transform.position - transform.position));
                        man2.ManDeath.Die();
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}