using System;
using UnityEngine;
using UnityEngine.UI;

public class VaweCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Button _buttonNextVawe;

    private int _vawe;

    public int Number => _vawe;

    public event Action VaweStarted;

    private void OnEnable()
    {
        _spawner.VaweFinished += OnVaweFinished;
        _buttonNextVawe.onClick.AddListener(OnButtonNextVaweClick);
    }

    private void Start()
    {
        VaweStarted?.Invoke();
        _buttonNextVawe.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _spawner.VaweFinished -= OnVaweFinished;
        _buttonNextVawe.onClick.RemoveListener(OnButtonNextVaweClick);
    }

    private void OnVaweFinished()
    {
        _vawe++;
        _buttonNextVawe.gameObject.SetActive(true);
    }

    private void OnButtonNextVaweClick()
    {
        VaweStarted?.Invoke();
        _buttonNextVawe.gameObject.SetActive(false);
    }
}
