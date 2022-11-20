using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private double _value;

    private double _startValue;

    public double Value => _value;
    public Vector3 Position => transform.position;

    public event Action<double> ValueChanged;
    public event Action<double> Died;
    public event Action<IDamageable> Killed;

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

        _startValue = value;
        _value = value;
        ValueChanged?.Invoke(_value);
    }

    private void TryDie()
    {
        if (_value < 1)
            Die();
    }

    private void Die()
    {
        Died?.Invoke(_startValue);
        Killed?.Invoke(this);
        gameObject.SetActive(false);
    }    
}
