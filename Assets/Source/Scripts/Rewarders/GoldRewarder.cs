using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRewarder : MonoBehaviour
{
    [SerializeField] private GoldCalculator _goldCalculator;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Wallet _wallet;

    private float _enemyHpMultiplicator = 0.15f;

    private void OnEnable()
    {
        _enemySpawner.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(double value)
    {
        double reward = value * _enemyHpMultiplicator * _goldCalculator.Multiplicator;

        _wallet.AddMoney(reward);
    }
}
