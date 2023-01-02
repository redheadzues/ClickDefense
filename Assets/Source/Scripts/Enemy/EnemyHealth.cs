using System;
using UnityEngine;
using NumbersForIdle;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private IdleNumber _value;

    private IdleNumber _startValue;

    public IdleNumber Value => _value;
    public Vector3 Position => transform.position;

    public event Action<IdleNumber> ValueChanged;
    public event Action<IdleNumber> Died;
    public event Action<IDamageable> Killed;

    public void TakeDamage(IdleNumber damage)
    {
        if(damage > 0)
        {
            _value -= damage;
            ValueChanged?.Invoke(_value);
        }

        if(TryDie())
        {
            Died?.Invoke(_startValue);
            Killed?.Invoke(this);
        }

    }

    public void SetValue(IdleNumber value)
    {

        _startValue = value;
        _value = value;
        ValueChanged?.Invoke(_value);
    }

    private bool TryDie()
    {
        if (_value < 1)
        {
            Die();
            return true;
        }
        else
            return false;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }    
}
