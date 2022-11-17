using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaweHealth : MonoBehaviour
{
    [SerializeField] private VaweCounter _vaweCounter;

    private float _healthMultiplicator = 1.5f;
    private float _baseHealth = 10;


    public double GetVaweHealth(int enemyCount = 10)
    {
        return _baseHealth * Mathf.Pow(_healthMultiplicator, _vaweCounter.Number) * enemyCount;
    }
}
