using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthRandomizer : MonoBehaviour
{
    [SerializeField] private float _healthSpred = 0.2f;

    private double _health;
    private int _count;


    public void Initialize(double health, int count)
    {
        _health = health;
        _count = count;
    }

    public bool GetHealthValue(out double value)
    {
        if(_count == 1)
        {
            value = _health;
            return _count-- > 0; 
        }

        float randomHealthMultiplicator = Random.Range(1 - _healthSpred, 1 + _healthSpred);

        value = _health / _count * randomHealthMultiplicator;
        _health -= value;

        return _count-- > 0;
    }
}
