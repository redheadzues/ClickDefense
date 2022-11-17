using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaweCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private int _vawe;

    public int Number => _vawe;

    public event Action VaweStarted;

    private void OnEnable()
    {
        _spawner.VaweFinished += OnVaweFinished;
    }

    private void Start()
    {
        VaweStarted?.Invoke();   
    }

    private void OnDisable()
    {
        _spawner.VaweFinished -= OnVaweFinished;
    }

    private void OnVaweFinished()
    {
        _vawe++;
        VaweStarted?.Invoke();
    }
}
