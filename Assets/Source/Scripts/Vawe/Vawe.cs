using System;
using UnityEngine;
using UnityEngine.UI;
using GameLevel;

public class Vawe : MonoBehaviour
{
    //[SerializeField] private EnemySpawner _spawner;
    //[SerializeField] private Button _buttonNextVawe;

    private Level _level;

    public event Action Started;
    public int Number => _level.Value;

    //private void Awake()
    //{
    //    _level = new Level();
    //    _spawner.Initialize(this);
    //}

    //private void OnEnable()
    //{
    //    _spawner.Finished += OnVaweFinished;
       // _buttonNextVawe.onClick.AddListener(OnButtonNextVaweClick);
    //}

    //private void Start()
    //{
    //    Started?.Invoke();
    //    //_buttonNextVawe.gameObject.SetActive(false);
    //}

    //private void OnDisable()
    //{
    //    _spawner.Finished -= OnVaweFinished;
        //_buttonNextVawe.onClick.RemoveListener(OnButtonNextVaweClick);
    //}

    //private void OnVaweFinished()
    //{
    //    _level.Increase();
    //    //_buttonNextVawe.gameObject.SetActive(true);
    //}

    //private void OnButtonNextVaweClick()
    //{
    //    Started?.Invoke();
        //_buttonNextVawe.gameObject.SetActive(false);
    //}
}
