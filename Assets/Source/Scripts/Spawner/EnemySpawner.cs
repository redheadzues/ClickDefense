using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;

public class EnemySpawner : ObjectsPool
{
    private float _secondsBetweenSpawn;
    private List<Vector3> _spawnPoints = new List<Vector3>();
    private Vawe _vawe;
    private ICoroutineRunner _coroutineRunner;
    public event Action Finished;

    public EnemySpawner(IEnemyFactory enemyFactory, IStaticDataService staticData, ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;

        SceneStaticData sceneData = staticData.ForLevel();

        InitializePool(enemyFactory, sceneData.EnemyTypeId);
        WriteSpawnPoint(sceneData);

        OnVaweStarted();
    }

    public void Initialize(Vawe vawe)
    {
        _vawe = vawe;
        _vawe.Started += OnVaweStarted;
    }


    private void WriteSpawnPoint(SceneStaticData staticData)
    {
        foreach (EnemySpawnPoint spawPoint in staticData.EnemySpawnPoint)
            _spawnPoints.Add(spawPoint.Position);
    }

    private void OnVaweStarted()
    {
        _coroutineRunner.StartCoroutine(OnSpawn());
    }

    private bool Spawn()
    {
        if (TryGetObject(out EnemyHealth enemy) == true)
        {
            enemy.transform.position = GetRandomPoint();
            enemy.ResetCurrentValue();
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

        return _spawnPoints[index];
    }

    private IEnumerator OnSpawn()
    {
        while (Spawn())
            yield return new WaitForSeconds(_secondsBetweenSpawn);
    }
}
