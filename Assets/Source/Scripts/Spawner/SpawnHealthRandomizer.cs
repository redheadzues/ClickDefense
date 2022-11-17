using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnHealthRandomizer : MonoBehaviour
{
    [SerializeField] private float _healthSpred = 0.2f;

    private double _health;
    private int _count;


    public void Initialize(double health, int count = 10)
    {
        _health = health;
        _count = count;
    }

    public bool GetHealthValue(out double value)
    {
        if(_count == 1)
        {
            value = Math.Round(_health);
            return _count-- > 0; 
        }

        float randomHealthMultiplicator = UnityEngine.Random.Range(1 - _healthSpred, 1 + _healthSpred);

        value = Math.Round(_health / _count * randomHealthMultiplicator);
        _health -= value;

        return _count-- > 0;
    }
}
