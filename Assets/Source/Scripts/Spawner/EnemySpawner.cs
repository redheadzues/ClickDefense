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
    [SerializeField] private SpawnHealthRandomizer _randomizer;

    public event Action VaweFinished;

    private void Awake()
    {
        InitializePool<EnemyHealth>(_template);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();
    }

    private void StartVawe(double health, int count)
    {
        _randomizer.Initialize(health, count);
    }

    private void Spawn()
    {
        if (_randomizer.GetHealthValue(out double health) == true)
        {
            if (TryGetObject<EnemyHealth>(out EnemyHealth enemy) == true)
            {
                enemy.gameObject.SetActive(true);
                enemy.SetValue(health);
                enemy.transform.position = GetRandomPoint();
            }
        }
        else
            VaweFinished?.Invoke();
    }

    private Vector3 GetRandomPoint()
    {
        int index = UnityEngine.Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[index].position;
    }

    private IEnumerator OnSpawn()
    {
        while(true)
        {
            Spawn();
            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }

}
