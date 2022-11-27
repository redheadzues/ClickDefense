using System;
using UnityEngine;

[RequireComponent(typeof(ITowerData))]
public class TowerParametrCalculator : MonoBehaviour, ITowerCalculatedData
{
    private ITowerData _tower;

    private const float _multiplicator = 1.07f;
    private const float _baseCostMultiplicator = 4.2f;
    private const int _baseCost = 50;

    public float CurrentRange => CalculateRange();

    public float CurrentAttackRate => CalculateAttackRate();

    public double CurrentDamage => CalculateDamage();

    public double CurrentUpgradeCost => CalculateCost();

    private void Awake()
    {
        _tower = GetComponent<ITowerData>();
    }

    private float CalculateRange()
    {
        return _tower.Range;
    }

    private float CalculateAttackRate()
    {
        return _tower.AttackRate;
    }

    private double CalculateDamage()
    {
        return _tower.Damage * Math.Pow(_multiplicator, _tower.Rank);  
    }

    private double CalculateCost()
    {
        return _baseCost * Math.Pow(_baseCostMultiplicator, _tower.Rank * _multiplicator) * _tower.Level;
    }
}
