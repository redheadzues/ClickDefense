using Assets.Source.Scripts.Infrustructure.Services.Factories;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    protected List<GameObject> _pool = new List<GameObject>();

    protected void InitializePool(IEnemyFactory enemyFactory)
    {
        for(int i = 0; i < _capacity; i++)
        {
            GameObject enemy =  enemyFactory.CreateEnemy(_container);
            enemy.SetActive(false);
            _pool.Add(enemy);
        }
    }

    protected void InitializePool<T>(T sample) where T : MonoBehaviour
    {
        GameObject template = sample.gameObject;

        for(int i = 0; i < _capacity; i++)
        {
            GameObject newExemplar = Instantiate(template, _container.transform);
            newExemplar.SetActive(false);
            _pool.Add(newExemplar);
        }
    }

    protected bool TryGetObject<T>(out T output) where T : MonoBehaviour
    {
        if (_pool.Count <= 0)
            output = null;
        else
        {
            GameObject exemplar = _pool.FirstOrDefault(deactiveExemplar => deactiveExemplar.activeSelf == false);
            output = exemplar.GetComponent<T>();
        }



        return output != null;
    }
}
