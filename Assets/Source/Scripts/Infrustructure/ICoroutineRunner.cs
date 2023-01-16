using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}