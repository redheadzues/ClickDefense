using System;
using UnityEngine;
using UnityEngine.UI;

public class Vawe : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Button _buttonNextVawe;
    [SerializeField] private GameLevelUnity _gameLevel;

    public event Action Started;

    private void Awake()
    {
        _spawner.Initialize(_gameLevel, this);
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
        _gameLevel.Increase();
        _buttonNextVawe.gameObject.SetActive(true);
    }

    private void OnButtonNextVaweClick()
    {
        Started?.Invoke();
        _buttonNextVawe.gameObject.SetActive(false);
    }
}
