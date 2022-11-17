using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRewarder : MonoBehaviour
{
    [SerializeField] private GoldCalculator _goldCalculator;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(double obj)
    {
        throw new NotImplementedException();
    }
}
