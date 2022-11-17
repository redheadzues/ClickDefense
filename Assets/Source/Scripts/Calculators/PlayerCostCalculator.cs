using System;
using UnityEngine;

public class PlayerCostCalculator : MonoBehaviour
{
    [SerializeField] private PlayerLevel _level;

    private float _baseLevelCostMultiplicator = 1.07f;
    private float _baseCost = 5;

    public double CurrentLevelUpgradeCost => _baseCost * Math.Pow(_level.Value, _baseLevelCostMultiplicator);
}
