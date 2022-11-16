using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthRandomizer : MonoBehaviour
{
    private double _health;
    private int _count;
    private float _upperBound;
    private float _lowerBound;

    public void Initialize(double health, int count)
    {
        _health = health;
        _count = count;
    }

    public double GetHealthValue()
    {
        return _health;
    }
}
