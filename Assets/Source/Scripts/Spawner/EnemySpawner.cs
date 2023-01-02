using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NumbersForIdle;

public class EnemySpawner : ObjectsPool
{
    [SerializeField] private EnemyHealth _template;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _healthSpred;

    private SpawnHealthRandomizer _randomizer;
    private IGetEnemyHealth _health;
    private Vawe _vawe;
    private List<IDamageable> _enemies = new List<IDamageable>();

    public event Action Finished;

    private void OnDisable()
    {
        _vawe.Started -= OnVaweStarted;
    }

    public void Initialize(IGetEnemyHealth healthGetter, Vawe vawe)
    {
        InitializePool<EnemyHealth>(_template);
        FillDamageableList();
        _randomizer = new SpawnHealthRandomizer(_healthSpred, healthGetter);
        _vawe = vawe;
        _vawe.Started += OnVaweStarted;

        _health = healthGetter;

    }

    private void FillDamageableList()
    {
        for(int i = 0; i< _pool.Count; i++)
        {
            if (_pool[i].TryGetComponent(out IDamageable damageable))
            {
                _enemies.Add(damageable);
            }
        }
    }

    private void TestingSpawn()
    {
        if (TryGetObject<EnemyHealth>(out EnemyHealth enemy) == true)
        {
            enemy.transform.position = GetRandomPoint();
            enemy.gameObject.SetActive(true);
            enemy.SetValue(new IdleNumber(10));
        }
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
                enemy.gameObject.SetActive(true);
                enemy.SetValue(health);
                enemy.transform.position = GetRandomPoint();
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
