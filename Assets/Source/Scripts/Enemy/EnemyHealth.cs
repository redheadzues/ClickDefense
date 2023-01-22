using System;
using UnityEngine;
using NumbersForIdle;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _value;

    private int _startValue;

    public int StartValue => _startValue;
    public int Value => _value;
    public Vector3 Position => transform.position;

    public event Action<int> ValueChanged;
    public event Action<IDamageable> Died;

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            _value -= damage;
            ValueChanged?.Invoke(_value);
        }

        if(TryDie())
            Died?.Invoke(this);
    }

    public void SetValue(int value)
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
