using System;
using NumbersForIdle;

public class TowerParametrsCalculator : ITowerCalculatedData
{
    private ITowerData _tower;

    private const float _multiplicator = 1.07f;
    private const float _baseCostMultiplicator = 4.2f;
    private const int _baseCost = 50;

    public float CurrentRange => CalculateRange();

    public float CurrentAttackRate => CalculateAttackRate();

    public IdleNumber CurrentDamage => CalculateDamage();

    public IdleNumber CurrentUpgradeCost => CalculateCost();

    public TowerParametrsCalculator(ITowerData tower)
    {
        _tower = tower;
    }

    private float CalculateRange()
    {
        return _tower.Range;
    }

    private float CalculateAttackRate()
    {
        return _tower.AttackRate;
    }

    private IdleNumber CalculateDamage()
    {
        IdleNumber damage = new(_tower.Damage * Math.Pow(_multiplicator, _tower.Rank));

        return damage;  
    }

    private IdleNumber CalculateCost()
    {
        IdleNumber cost = new(_baseCost);
        cost *= Math.Pow(_baseCostMultiplicator, _tower.Rank * _multiplicator);
        cost *= _tower.Level;

        return cost;
    }
}
