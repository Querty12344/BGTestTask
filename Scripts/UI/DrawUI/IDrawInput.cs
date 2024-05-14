using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.Scripts.UI.DrawUI
{
    public interface IDrawInput
    {
        public event Action<Vector3[]> SomethingDrawn;
    }
}