using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectsPool
{
    [SerializeField] private EnemyHealth _template;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private VaweHealth _vaweHealth;
    [SerializeField] private VaweCounter _vaweCounter;
    [SerializeField] private SpawnHealthRandomizer _randomizer;

    private List<IDamageable> _enemies = new List<IDamageable>();

    public event Action VaweFinished;
    public event Action<double> EnemyDied;

    private void Awake()
    {
        InitializePool<EnemyHealth>(_template);
        FillDamageableList();
    }

    private void OnEnable()
    {
        _vaweCounter.VaweStarted += OnVaweStarted;
    }

    private void OnDisable()
    {
        _vaweCounter.VaweStarted -= OnVaweStarted;

        for (int i = 0; i < _enemies.Count; i++)
            _enemies[i].Died -= OnDied;
    }

    private void FillDamageableList()
    {
        for(int i = 0; i< _pool.Count; i++)
        {
            if (_pool[i].TryGetComponent(out IDamageable damageable))
            {
                _enemies.Add(damageable);
                damageable.Died += OnDied;
            }
        }
    }

    private void TestingSpawn()
    {
        if (TryGetObject<EnemyHealth>(out EnemyHealth enemy) == true)
        {
            enemy.transform.position = GetRandomPoint();
            enemy.gameObject.SetActive(true);
            enemy.SetValue(10);
        }
    }

    private void OnVaweStarted()
    {
        double health = _vaweHealth.GetVaweHealth();
        _randomizer.Initialize(health);

        StartCoroutine(OnSpawn());
    }

    private bool Spawn()
    {
        if (_randomizer.GetHealthValue(out double health) == true)
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
            VaweFinished?.Invoke();
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

    private void OnDied(double value)
    {
        EnemyDied?.Invoke(value);
    }
}
