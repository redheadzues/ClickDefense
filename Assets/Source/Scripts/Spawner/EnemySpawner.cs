using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.CharactersComponent;

public class EnemySpawner
{
    private readonly float _secondsBetweenSpawn;
    private readonly List<Vector3> _spawnPoints = new List<Vector3>();
    private readonly SceneStaticData _sceneData;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly ICharacterFactory _characterFactory;
    private List<EnemyTypeId> _vaweSpawnList = new List<EnemyTypeId>();
    private int _spawnIndex;
    private int _deathCount;

    public event Action Finished;

    public EnemySpawner(ICharacterFactory enemyFactory, IStaticDataService staticData, ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
        _characterFactory = enemyFactory;
        _sceneData = staticData.ForLevel();

        //InitializePool(enemyFactory, _sceneData);
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
        _deathCount = 0;
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
            return false;

        GameObject enemy = _characterFactory.CreateEnemy(_vaweSpawnList[_spawnIndex]);
        enemy.transform.position = GetRandomPoint();
        enemy.GetComponent<Death>().Happend += OnDeathHappend;
        _spawnIndex++;

        return true;
    }

    private void OnDeathHappend(Death death)
    {
        death.Happend -= OnDeathHappend;
        _deathCount++;

        if (_deathCount == _vaweSpawnList.Count)
            Finished.Invoke();
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
