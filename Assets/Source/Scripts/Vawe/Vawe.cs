using System;
using UnityEngine;
using UnityEngine.UI;
using GameLevel;
using NumbersForIdle;

public class Vawe : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Button _buttonNextVawe;

    private Level _level;
    private EnemyHealthCalculator _enemyHealthCalculator;

    public event Action Started;
    public int Number => _level.Value;
    public IdleNumber EnemyHealthValue => _enemyHealthCalculator.GetValue();

    private void Awake()
    {
        _level = new Level();
        _enemyHealthCalculator = new EnemyHealthCalculator(_level);
        _spawner.Initialize(this);
    }

    private void OnEnable()
    {
        _spawner.Finished += OnVaweFinished;
        _buttonNextVawe.onClick.AddListener(OnButtonNextVaweClick);
    }

    private void Start()
    {
        Started?.Invoke();
        _buttonNextVawe.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _spawner.Finished -= OnVaweFinished;
        _buttonNextVawe.onClick.RemoveListener(OnButtonNextVaweClick);
    }

    private void OnVaweFinished()
    {
        _level.Increase();
        _buttonNextVawe.gameObject.SetActive(true);
    }

    private void OnButtonNextVaweClick()
    {
        Started?.Invoke();
        _buttonNextVawe.gameObject.SetActive(false);
    }
}
