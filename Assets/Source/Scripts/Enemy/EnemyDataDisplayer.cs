using TMPro;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class EnemyDataDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textHealth;

    private IDamageable _damageable;

    private void Awake()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void OnEnable()
    {
        _damageable.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _damageable.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(double health)
    {
        _textHealth.text = health.ToString();
    }
}
