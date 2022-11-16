using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaweHealth : MonoBehaviour
{
    private int _vawe = 0;
    private float _healthMultiplicator = 1.5f;
    private float _baseHealth = 10;
    private int _enemyCount = 10;

    private double GetVaweHealth()
    {
        return _baseHealth * Mathf.Pow(_healthMultiplicator, _vawe) * _enemyCount;
    }
}
