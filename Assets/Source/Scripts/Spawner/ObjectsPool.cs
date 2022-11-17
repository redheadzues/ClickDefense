using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _container;

    protected List<GameObject> _pool = new List<GameObject>();

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
        GameObject exemplar = _pool.FirstOrDefault(deactiveExemplar => deactiveExemplar.activeSelf == false);
        output = exemplar.GetComponent<T>();

        return output != null;
    }
}
