using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.CharactersComponent;

public class EnemySpawner : ObjectsPool
{
    private readonly float _secondsBetweenSpawn;
    private readonly List<Vector3> _spawnPoints = new List<Vector3>();
    private readonly SceneStaticData _sceneData;
    private readonly ICoroutineRunner _coroutineRunner;
    private List<EnemyTypeId> _vaweSpawnList = new List<EnemyTypeId>();
    private int _spawnIndex;

    public event Action Finished;

    public EnemySpawner(IEnemyFactory enemyFactory, IStaticDataService staticData, ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;

        _sceneData = staticData.ForLevel();

        InitializePool(enemyFactory, _sceneData);
        WriteSpawnPoint(_sceneData);
        _secondsBetweenSpawn = _sceneData.SecondsBetweenSpawn;
    }

    public void StartNewVawe(int vaweNumber)
    {
        ResetSpawnList();
        FormVaweSpawnList(vaweNumber);

        _coroutineRunner.StartCoroutine(OnSpawn());
    }

    private void FormVaweSpawnList(int vaweNumber)
    {
        foreach (VaweCell vaweCell in _sceneData.VawesData[vaweNumber-1].VaweCells)
        {
            for(int i = 0; i < vaweCell.Count; i++)
                _vaweSpawnList.Add(vaweCell.Type);
        }
    }

    private void ResetSpawnList()
    {
        _vaweSpawnList.Clear();
        _spawnIndex = 0;
    }

    private void WriteSpawnPoint(SceneStaticData staticData)
    {
        foreach (EnemySpawnPoint spawPoint in staticData.EnemySpawnPoint)
            _spawnPoints.Add(spawPoint.Position);
    }

    private bool Spawn()
    {
        if(_spawnIndex == _vaweSpawnList.Count)
        {
            Finished?.Invoke();
            return false;
        }

        if (TryGetObject(_vaweSpawnList[_spawnIndex] ,out Health enemy) == true)
        {
            enemy.transform.position = GetRandomPoint();
            enemy.gameObject.SetActive(true);
            enemy.ResetCurrentValue();

            _spawnIndex++;
        }

        return true;
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
