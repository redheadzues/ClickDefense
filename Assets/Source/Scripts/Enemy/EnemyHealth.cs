using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private double _value;

    public double Value => _value;

    public event Action<double> ValueChanged;

    public void TakeDamage(double damage)
    {
        if(damage > 0)
        {
            _value -= damage;
            ValueChanged?.Invoke(_value);
        }

        TryDie();
    }

    public void SetValue(double value)
    {
        _value = value;
        ValueChanged?.Invoke(_value);
    }

    private void TryDie()
    {
        if (_value <= 0)
            Die();
    }

    private void Die()
    {

    }    
}
