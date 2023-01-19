using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NumbersForIdle;
using Assets.Source.Scripts.Infrustructure.Services.Factories;

public class EnemySpawner : ObjectsPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _healthSpred;

    private IEnemyFactory _enemyFactory;

    private SpawnHealthRandomizer _randomizer;
    private Vawe _vawe;

    public event Action Finished;

    public void Construct(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        InitializePool(_enemyFactory);
    }

    private void OnDisable()
    {
        _vawe.Started -= OnVaweStarted;
    }

    public void Initialize(Vawe vawe)
    {
        _randomizer = new SpawnHealthRandomizer(_healthSpred, vawe);
        _vawe = vawe;
        _vawe.Started += OnVaweStarted;
    }

    private void OnVaweStarted()
    {
        _randomizer.Set(10);
        StartCoroutine(OnSpawn());
    }

    private bool Spawn()
    {
        if (_randomizer.GetHealthValue(out IdleNumber health) == true)
        {
            if (TryGetObject<EnemyHealth>(out EnemyHealth enemy) == true)
            {
                enemy.transform.position = GetRandomPoint();
                enemy.SetValue(health);
                enemy.gameObject.SetActive(true);
            }

            return true;
        }
        else
        {
            Finished?.Invoke();
            return false;
        }
    }

    private Vector3 GetRandomPoint()
    {
        int index = UnityEngine.Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[index].position;
    }

    private IEnumerator OnSpawn()
    {
        while (Spawn())
            yield return new WaitForSeconds(_secondsBetweenSpawn);
    }
}
