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

    public event Action VaweFinished;

    private void Awake()
    {
        InitializePool<EnemyHealth>(_template);
    }

    private void OnEnable()
    {
        _vaweCounter.VaweStarted += OnVaweStarted;
    }

    private void OnDisable()
    {
        _vaweCounter.VaweStarted -= OnVaweStarted;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TestingSpawn();
    }

    private void TestingSpawn()
    {
        if (TryGetObject<EnemyHealth>(out EnemyHealth enemy) == true)
        {
            enemy.gameObject.SetActive(true);
            enemy.SetValue(10);
            enemy.transform.position = GetRandomPoint();
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
}
