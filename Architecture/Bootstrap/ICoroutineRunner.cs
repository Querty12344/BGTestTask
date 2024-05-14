using System.Collections;
using UnityEngine;

namespace Project.Scripts.Architecture.Bootstrap
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopAllCoroutines();
    }
}