using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool
{
    private int _capacity = 30;
    private Transform _container;

    protected List<GameObject> _pool = new List<GameObject>();

    protected void InitializePool(IEnemyFactory enemyFactory, VawesData vaweData)
    {

        foreach(VaweCell vaweCell in vaweData.VaweCell)
            for(int i = 0; i < vaweCell.Count; i++)
            {
                GameObject enemy = enemyFactory.CreateEnemy(_container, vaweCell.Type);
                enemy.SetActive(false);
                _pool.Add(enemy);
            }
    }

    protected bool TryGetObject<T>(out T output) where T : MonoBehaviour
    {
        if (_pool.Count <= 0)
            output = null;
        else
        {
            GameObject exemplar = _pool.FirstOrDefault(deactiveExemplar => deactiveExemplar.activeSelf == false);
            output = exemplar?.GetComponent<T>();
        }

        return output != null;
    }
}
