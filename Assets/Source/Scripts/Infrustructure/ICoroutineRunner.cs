using Assets.Source.Scripts.Infrustructure.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}