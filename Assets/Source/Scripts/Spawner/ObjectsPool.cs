using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool
{
    private Transform _container;

    private List<Enemy> _pool = new List<Enemy>();
    Dictionary<EnemyTypeId, int> _createData = new Dictionary<EnemyTypeId, int>();

    protected void InitializePool(IEnemyFactory enemyFactory, SceneStaticData sceneData)
    {
        _container = new GameObject("EnemyContainer").transform;
        GameBootstraper.print(sceneData.ToString());
        DetermineNumberOfInstancesToCreate(sceneData);
        FillPool(enemyFactory);
    }

    protected bool TryGetObject<T>(EnemyTypeId typeId ,out T output) where T : MonoBehaviour
    {
        if (_pool.Count <= 0)
            output = null;
        else
        {
            Enemy exemplar = _pool.FirstOrDefault(deactiveExemplar => 
            deactiveExemplar.gameObject.activeSelf == false 
            && 
            deactiveExemplar.TypeId == typeId);


            output = exemplar?.GetComponent<T>();
        }

        return output != null;
    }

    private void FillPool(IEnemyFactory enemyFactory)
    {
        foreach (EnemyTypeId type in _createData.Keys)
        {
            for (int i = 0; i < _createData[type]; i++)
            {
                GameObject enemy = enemyFactory.CreateEnemy(_container, type);                
                enemy.SetActive(false);                
                _pool.Add(enemy.GetComponent<Enemy>());
            }
        }
    }

    private void DetermineNumberOfInstancesToCreate(SceneStaticData sceneData)
    {
        foreach (VaweData vaweData in sceneData.VawesData)
        {
            foreach (VaweCell vaweCell in vaweData.VaweCells)
            {
                if (_createData.ContainsKey(vaweCell.Type))
                {
                    if (_createData[vaweCell.Type] < vaweCell.Count)
                        _createData[vaweCell.Type] = vaweCell.Count;
                }
                else
                {
                    _createData.Add(vaweCell.Type, vaweCell.Count);
                }
            }
        }
    }
}
