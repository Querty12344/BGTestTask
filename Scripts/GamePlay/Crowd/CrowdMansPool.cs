using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.GamePlay
{
    public class CrowdMansPool : MonoBehaviour
    {
        [SerializeField] private CrowdMansLayout _mansLayout;
        public event Action Empty;
        private bool _initialized;
        private List<ManFacade> _manFacades = new List<ManFacade>();
        private bool _enabled;

        public void Construct()
        {
            _initialized = true;
        }

        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public List<ManFacade> GetMans()
        {
            return _manFacades;
        }

        public void AddMan(ManFacade man, ManMove collisioned = null)
        {
            _manFacades.Add(man);
            _mansLayout.AddMan(man.GetComponent<ManMove>(), collisioned);
            man.Mover.Init();
            man.ManDeath.SetPool(this);
        }

        public void RemoveMan(ManFacade facade)
        {
            _manFacades.Remove(facade);
            if (_enabled && _manFacades.Count == 0)
            {
                Empty?.Invoke();
            }
        }
    }
}