using System;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;

    public Action Happend;
    public int Reward { get; private set; }

    private void OnEnable()
    {
        _health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnValueChanged;
    }

    public void SetReward(int value)
    {
        Reward = value;
    }

    private void OnValueChanged(int health)
    {
        if(health < 1)
            Die();
    }

    private void Die()
    {
        Happend?.Invoke();
        gameObject.SetActive(false);
    }
}
