using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine.SceneManagement;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;

public class EnemySpawner : ObjectsPool
{
    private float _secondsBetweenSpawn;
    private EnemyTypeId _enemyTypeId;

    private IEnemyFactory _enemyFactory;

    private List<Vector3> _spawnPoints;
    private Vawe _vawe;
    private StaticDataService _staticData;

    public event Action Finished;

    public void Construct(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        InitializePool(_enemyFactory, _enemyTypeId);
    }

    private void SetSpawnPoint()
    {
        string sceneKey = SceneManager.GetActiveScene().name;
        SceneStaticData levelData = _staticData.ForLevel(sceneKey);

        foreach (EnemySpawnPoint spawPoint in levelData.EnemySpawnPoint)
            _spawnPoints.Add(spawPoint.Position);
    }

    private void OnDisable()
    {
        _vawe.Started -= OnVaweStarted;
    }

    public void Initialize(Vawe vawe)
    {
        _vawe = vawe;
        _vawe.Started += OnVaweStarted;
    }

    private void OnVaweStarted()
    {
        print("started");
        StartCoroutine(OnSpawn());
    }

    private bool Spawn()
    {
        if (TryGetObject<EnemyHealth>(out EnemyHealth enemy) == true)
        {
            enemy.transform.position = GetRandomPoint();
            enemy.gameObject.SetActive(true);
            return true;
        }
        else
        {
            Finished?.Invoke();
            return true;
        }
    }

    private Vector3 GetRandomPoint()
    {
        int index = UnityEngine.Random.Range(0, _spawnPoints.Count);

        return Vector3.zero;/*_spawnPoints[index].position*/
    }

    private IEnumerator OnSpawn()
    {
        while (Spawn())
            yield return new WaitForSeconds(_secondsBetweenSpawn);
    }
}
